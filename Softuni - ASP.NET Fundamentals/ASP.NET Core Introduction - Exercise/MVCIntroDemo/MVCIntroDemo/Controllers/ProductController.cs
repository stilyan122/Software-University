using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models.Product;
using System.Text;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        private ILogger logger;

        private IEnumerable<ProductViewModel> products =
            new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50
                }
            };

        public ProductController(ILogger<ProductController> logger)
        {
            this.logger = logger;
        }

        [ActionName("My-Products")]
        public IActionResult All(string? keyword)
        {
            if (keyword != null)
            {
                var filtered = products
                    .Where(x => x.Name
                    .ToLower()
                    .Contains(keyword.ToLower()));

                return View(filtered);
            }

            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = this.products
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var str = ProductsAsString();

            return Content(str);
        }

        public IActionResult AllAsTextFile()
        {
            var str = ProductsAsString();

            Response.Headers.Add(HeaderNames.ContentDisposition,
                @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(str), "text/plain");
        }
        
        private string ProductsAsString()
        {
            var sb = new StringBuilder();

            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: " +
                    $"{product.Name} - {product.Price} lv.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
