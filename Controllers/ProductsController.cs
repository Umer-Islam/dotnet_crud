using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crud.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = new List<Product>
        {
new Product {Id = Guid.NewGuid(), Name ="keyboard", Price=9.99m,Description="mechanical keyboard with back lights"},
new Product {Id = Guid.NewGuid(), Name ="mouse", Price=4,Description="mouse with rgb lights"}
        };
        [HttpPost]
        public IActionResult Create([FromBody] Product newProduct)
        {
            try
            {
                newProduct.Id = Guid.NewGuid();
                products.Add(newProduct);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // return BadRequest(ex.Message);
                return UnprocessableEntity();
            }
        }
        [HttpGet]
        [HttpHead]
        public IActionResult Read()
        {
            if (products.Count > 0)
            {

                return Ok(products);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ReadById(Guid id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            return Ok(updatedProduct);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }
    }
}