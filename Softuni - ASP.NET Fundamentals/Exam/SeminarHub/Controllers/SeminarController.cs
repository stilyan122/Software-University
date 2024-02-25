using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Category;
using SeminarHub.Models.Seminar;
using System.Globalization;
using System.Security.Claims;
using static SeminarHub.Data.Constants.DataConstants.SeminarConstants;

namespace SeminarHub.Controllers
{
    /// <summary>
    /// Authorized controller for logged-in users
    /// </summary>
    [Authorize]
    public class SeminarController : Controller
    {
        /// <summary>
        /// Context field
        /// </summary>
        private readonly SeminarHubDbContext context;

        /// <summary>
        /// Constructor for injectint a context
        /// </summary>
        /// <param name="data"></param>
        public SeminarController(SeminarHubDbContext data)
        {
            this.context = data;  
        }

        /// <summary>
        /// Add Get Method
        /// </summary>
        /// <returns>Form View</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormModel()
            {
                Categories = await this.GetCategories()
            };

            return View(model); 
        }

        /// <summary>
        /// Add Post Method
        /// </summary>
        /// <param name="model">FormModel</param>
        /// <returns>Adds and redirects to action</returns>
        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormModel model)
        {
            DateTime date;

            if (!ModelState.IsValid || 
                !DateTime.TryParseExact(model.DateAndTime,
                DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                var categories = await this.GetCategories();
                model.Categories = categories;
                return View(model);
            }

            string userId = this.GetCurrentUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            Seminar entity = new Seminar()
            {
                CategoryId = model.CategoryId,
                DateAndTime = date,
                Details = model.Details,
                Duration = model.Duration,
                Lecturer = model.Lecturer,
                OrganizerId = userId,
                Topic = model.Topic
            };

            await this.context.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        /// <summary>
        /// All Method
        /// </summary>
        /// <returns>A View with loaded models</returns>
        public async Task<IActionResult> All()
        {
            var models = await this.context
                .Seminars
                .AsNoTracking()
                .Include(s => s.Category)
                .Select(s => new SeminarViewModel()
                {
                    DateAndTime = s.DateAndTime.ToString(DateTimeFormat),
                    Category = s.Category.Name,
                    Duration = s.Duration,
                    Id = s.Id,
                    Lecturer = s.Lecturer,
                    Organizer = s.Organizer.UserName,
                    Topic = s.Topic
                })
            .ToListAsync();

            return View(models);
        }

        /// <summary>
        /// Joined Method
        /// </summary>
        /// <returns>A View with joined models</returns>
        public async Task<IActionResult> Joined()
        {
            var currentUserId = this.GetCurrentUserId();

            if (currentUserId == null)
            {
                return Unauthorized();
            }

            var joined = await this.context
                .SeminarsParticipants
                .AsNoTracking()
                .Include(us => us.Seminar)
                .ThenInclude(s => s.Category)
                .Where(us => us.ParticipantId == currentUserId)
                .Select(us => new SeminarViewModel()
                {
                    Id = us.Seminar.Id,
                    DateAndTime = us.Seminar.DateAndTime.ToString(DateTimeFormat),
                    Category = us.Seminar.Category.Name,
                    Duration = us.Seminar.Duration,
                    Lecturer = us.Seminar.Lecturer,
                    Organizer = us.Seminar.Organizer.UserName,
                    Topic = us.Seminar.Topic
                })
                .ToListAsync();

            return View(joined);
        }

        /// <summary>
        /// Edid Get Method
        /// </summary>
        /// <param name="id">Id of entity to edit</param>
        /// <returns>A Form with entity to be edited</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await this.context
                .Seminars
                .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null)
            {
                return BadRequest();
            }

            var currentUserId = this.GetCurrentUserId();

            if (entity.OrganizerId != currentUserId)
            {
                return Unauthorized();
            }

            var categories = await this.GetCategories();

            var model = new SeminarFormModel()
            {
                DateAndTime = entity.DateAndTime.ToString(DateTimeFormat),
                Categories = categories,
                CategoryId = entity.CategoryId,
                Details = entity.Details,
                Duration = entity.Duration,
                Lecturer = entity.Lecturer,
                Topic = entity.Topic
            };

            return View(model);
        }

        /// <summary>
        /// Edit Post Method
        /// </summary>
        /// <param name="id">Id of the entity to edit</param>
        /// <param name="model">Model to update with</param>
        /// <returns>Edits and redirects to View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, SeminarFormModel model)
        {
            DateTime date;

            if (!ModelState.IsValid ||
                !DateTime.TryParseExact(model.DateAndTime,
                DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                var categories = await this.GetCategories();
                model.Categories = categories;
                return View(model);
            }

            var entity = await this.context
                .Seminars
                .FirstOrDefaultAsync(s => s.Id == id);

            var currentUserId = this.GetCurrentUserId();

            if (entity == null)
            {
                return BadRequest();
            }

            if (entity.OrganizerId != currentUserId)
            {
                return Unauthorized();
            }

            entity.Lecturer = model.Lecturer;
            entity.CategoryId = model.CategoryId;
            entity.DateAndTime = date;
            entity.Details = model.Details;
            entity.Topic = model.Topic;
            entity.Duration = model.Duration;

            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        /// <summary>
        /// Join Method
        /// </summary>
        /// <param name="id">Id of the entity to join</param>
        /// <returns>Joins if needed and redirects to View</returns>
        public async Task<IActionResult> Join(int id)
        {
            var currentUserId = this.GetCurrentUserId();

            var list = this.context
                .SeminarsParticipants
                .Where(sp => sp.SeminarId == id && sp.ParticipantId == currentUserId)
                .ToList();

            var seminar = await this.context
                .Seminars
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null || seminar.OrganizerId == currentUserId)
            {
                return BadRequest();
            }

            if (list.Count == 0)
            {
                var entity = new SeminarParticipant()
                {
                    ParticipantId = currentUserId,
                    SeminarId = id
                };

                await this.context.SeminarsParticipants.AddAsync(entity);
                await this.context.SaveChangesAsync();

                return RedirectToAction("Joined");
            }
            else
            {
                return RedirectToAction("All");
            }
        }

        /// <summary>
        /// Leave Method
        /// </summary>
        /// <param name="id">Id of the entity to leave</param>
        /// <returns>Leaves if needed ad redirects to View</returns>
        public async Task<IActionResult> Leave(int id)
        {
            var currentUserId = this.GetCurrentUserId();

            var list = this.context
                .SeminarsParticipants
                .Where(sp => sp.SeminarId == id && sp.ParticipantId == currentUserId)
                .ToList();

            if (list.Count != 0)
            {
                var itemToRemove = list.First(sp => sp.SeminarId == id && sp.ParticipantId == currentUserId);

                if (itemToRemove == null)
                {
                    return BadRequest();
                }

                context.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Joined");
        }

        /// <summary>
        /// Details Method
        /// </summary>
        /// <param name="id">Id of the entity for which are the details</param>
        /// <returns>View with the details</returns>
        public async Task<IActionResult> Details(int id)
        {
            var entity = await this.context
                .Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null)
            {
                return BadRequest();
            }

            var model = new SeminarDetailsViewModel()
            {
                DateAndTime = entity.DateAndTime.ToString(DateTimeFormat),
                Category = entity.Category.Name,
                Details = entity.Details,
                Duration = entity.Duration,
                Id = entity.Id,
                Lecturer = entity.Lecturer,
                Organizer = entity.Organizer.UserName,
                Topic = entity.Topic
            };

            return View(model);
        }

        /// <summary>
        /// Delete Get Method
        /// </summary>
        /// <param name="id">Id of the entity to delete</param>
        /// <returns>A page to indicate if the user is sure to delete</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await this.context
               .Seminars
               .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null)
            {
                return BadRequest();
            }

            var currentUserId = this.GetCurrentUserId();

            if (entity.OrganizerId != currentUserId)
            {
                return Unauthorized();
            }

            var model = new SeminarDeleteViewModel()
            {
                Id = entity.Id,
                DateAndTime = entity.DateAndTime,
                Lecturer = entity.Lecturer,
                Topic = entity.Topic
            };

            return View(model);
        }

        /// <summary>
        /// Delete Post Method
        /// </summary>
        /// <param name="model">model to delete</param>
        /// <returns>Deletes and redirects to View</returns>
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(SeminarDeleteViewModel model)
        {
            var entity = await this.context
               .Seminars
               .FirstOrDefaultAsync(s => s.Id == model.Id);

            if (entity == null)
            {
                return BadRequest();
            }

            var currentUserId = this.GetCurrentUserId();

            if (entity.OrganizerId != currentUserId)
            {
                return Unauthorized();
            }

            context.SeminarsParticipants
                .RemoveRange(context.SeminarsParticipants.Where(sp => sp.SeminarId == model.Id));
            context.Seminars.Remove(entity);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        /// <summary>
        /// Private method for accessing current user id
        /// </summary>
        /// <returns>Id / null</returns>
        private string GetCurrentUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        /// <summary>
        /// Private method for loading all the categories in the DB
        /// </summary>
        /// <returns>A collection of those categories mapped to view models</returns>
        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
            => await this.context
            .Categories
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }
}
