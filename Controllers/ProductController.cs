using Microsoft.AspNetCore.Mvc;

namespace Sample_Dotnet_Api_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "High-performance laptop" },
            new Product { Id = 2, Name = "Mouse", Price = 29.99m, Description = "Wireless mouse" },
            new Product { Id = 3, Name = "Keyboard", Price = 79.99m, Description = "Mechanical keyboard" }
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllProducts")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            _logger.LogInformation("Getting all products");
            return Ok(Products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found");

            _logger.LogInformation("Getting product with ID: {id}", id);
            return Ok(product);
        }

        [HttpPost(Name = "CreateProduct")]
        public ActionResult<Product> Post([FromBody] CreateProductRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) || request.Price <= 0)
                return BadRequest("Invalid product data");

            var newProduct = new Product
            {
                Id = Products.Max(p => p.Id) + 1,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description
            };

            Products.Add(newProduct);
            _logger.LogInformation("Product created with ID: {id}", newProduct.Id);
            return CreatedAtRoute("GetProductById", new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public ActionResult<Product> Put(int id, [FromBody] UpdateProductRequest request)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found");

            product.Name = request.Name ?? product.Name;
            product.Price = request.Price > 0 ? request.Price : product.Price;
            product.Description = request.Description ?? product.Description;

            _logger.LogInformation("Product updated with ID: {id}", id);
            return Ok(product);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public ActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found");

            Products.Remove(product);
            _logger.LogInformation("Product deleted with ID: {id}", id);
            return NoContent();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateProductRequest
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}