using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TaskController(TaskBoardAppDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await data.Tasks.AddAsync(task);
            await data.SaveChangesAsync();

            var boards = data.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await data
                .Tasks
                .Where(t => t.Id == id)
                .Include(t => t.Board)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Boards = GetBoards();

                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            var task = await data.Tasks.FindAsync(model.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            data.Tasks.Remove(task);
            await data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        private IEnumerable<TaskBoardModel> GetBoards()
        {
            return data
                .Boards
                .Select(b => new TaskBoardModel
                {
                    Id = b.Id,
                    Name = b.Name,
                });
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
