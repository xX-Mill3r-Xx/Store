using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos;
using Store.Api.Models;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products =
        [
            new Product
            {
                Id = 1,
                Name = "Notebook",
                Price = 4500m
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 150m
            }
        ];

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAll()
        {
            var response = Products
                .Select(product => new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                })
                .ToList();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductResponse> GetById(int id)
        {
            var product = Products.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ProductResponse> Create(CreateProductRequest request)
        {
            var nextId = Products.Count = 0
                ? 1
                : Products.Max(product => product.Id) + 1;

            var product = new Product
            {
                Id,
                Name = request.Name,
                Price = request.Price,
            };

            Products.Add(product);

            var response = new ProductResponse
            {
                Id= product.Id,
                Name = product.Name,
                Price = product.Price,  
            };

            return CreateAction(
                nameof(GetById),
                new { id = product.Id },
                response);
        }
    }
}