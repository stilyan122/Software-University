using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
            => this.productService = productService;

        /// <summary>
        /// Gets a list with all products.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET /api/products
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with a list of all products</response>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return this.productService.GetAllProducts();
        }

        /// <summary>
        /// Gets a product by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET /api/products/{id}
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with the product</response>
        /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = this.productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /api/products
        ///     {
        ///         "name": "Candy",
        ///         "description": "Chocolate"
        ///     }
        /// </remarks>
        /// <response code="201">Returns "Created" with the created product</response>
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product) 
        {
            product = this.productService.CreateProduct(product.Name,
                product.Description);

            return CreatedAtAction("GetProducts", product);
        }

        /// <summary>
        /// Edits a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT /api/products/{id}
        ///     {
        ///         "name": "Candy",
        ///         "description": "Chocolate"
        ///     }
        /// </remarks>
        /// <response code="204">Returns "No Content"</response>
        /// <response code="400">Returns "Bad Request" when an invalid request is sent</response>
        /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
        [HttpPut("{id}")]
        public ActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProduct(id, product);

            return NoContent();
        }

        /// <summary>
        /// Edits a product partially.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PATCH /api/products/{id}
        ///     {
        ///         "name": "New Candy"
        ///     }
        /// </remarks>
        /// <response code="204">Returns "No Content"</response>
        /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
        [HttpPatch("{id}")]
        public ActionResult PatchProduct(int id, Product product)
        {
            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProductPartially(id, product);

            return NoContent();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     DELETE /api/products/{id}
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with the deleted product</response>
        /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            var product = this.productService.DeleteProduct(id);

            return product;
        }
    }
}
