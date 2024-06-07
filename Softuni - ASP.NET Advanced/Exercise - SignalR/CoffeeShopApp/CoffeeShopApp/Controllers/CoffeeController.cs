namespace CoffeeShopApp.Controllers
{
    using CoffeeShopApp.Hubs;
    using CoffeeShopApp.Services;
    using Microsoft.AspNetCore.Mvc;

    public class CoffeeController : Controller
    {
        private readonly ILogger<CoffeeController> _logger;
        private readonly IOrderService orderService;
        private readonly CoffeeHub coffeeHub;

        public CoffeeController(ILogger<CoffeeController> logger,
            IOrderService orderService, 
            CoffeeHub coffeeHub)
        {
            _logger = logger;
            this.orderService = orderService;
            this.coffeeHub = coffeeHub;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
