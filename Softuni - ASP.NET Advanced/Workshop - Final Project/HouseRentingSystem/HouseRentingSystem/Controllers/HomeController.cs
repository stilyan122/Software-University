using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Models;
using HouseRentingSystem.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService _houses;

        public HomeController(IHouseService houses)
        {
            _houses = houses;
        }

        public async Task<IActionResult> Index()
        {
            var houses = await _houses.LastThreeHouses();
            return View(houses);
        }

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
