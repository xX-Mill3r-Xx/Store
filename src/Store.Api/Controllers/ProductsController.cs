using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = new[]
            {
                new
                {
                    Id = 1, 
                    Name = "NoteBook", 
                    Price = 4500.00m
                },
                new 
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 150.00m
                }
            };

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = new
            {
                Id = id,
                Name = "NoteBook",
                Price = 4500.00m
            };

            return Ok(product);
        }
    }
}
