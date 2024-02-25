namespace ForumApp.Controllers
{
    using ForumApp.Core.Contracts;
    using ForumApp.Core.Models;
    using ForumApp.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class PostController : Controller
    {
        private IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var entities = await service.GetAllAsync();
            var models = entities.Select(m => new PostViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                Content = m.Content
            });

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            await service.AddAsync(model);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await service
                .GetByIdAsync(id);

            if (entity == null)
            {
                return RedirectToAction("Error");
            }

            var model = new PostFormModel()
            {
                Title = entity.Title,
                Content = entity.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await service.GetByIdAsync(id);

            if (post == null)
            {
                return RedirectToAction("Error");
            }

            post.Content = model.Content;
            post.Title = model.Title;

            await service.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("All");
        }

        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
