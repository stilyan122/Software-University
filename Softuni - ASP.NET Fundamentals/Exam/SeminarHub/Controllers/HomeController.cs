using Microsoft.AspNetCore.Mvc;

namespace SeminarHub.Controllers
{
    /// <summary>
    /// Default Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger field
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor for injecting a logger (DI)
        /// </summary>
        /// <param name="logger">Logger</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Default Action
        /// </summary>
        /// <returns>Index View</returns>
        public IActionResult Index()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Seminar");
            }

            return View();
        }
    }
}