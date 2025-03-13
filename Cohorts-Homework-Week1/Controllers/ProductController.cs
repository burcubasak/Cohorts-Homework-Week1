using Cohorts_Homework_Week1.Models;
using Cohorts_Homework_Week1.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Cohorts_Homework_Week1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<Product> _validator;

        public ProductController(IProductRepository repository, IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;

        }

        [HttpGet("List")]
        public IActionResult GetAll([FromQuery] string? name)
        {
            var products = _repository.GetAll(name);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound(new { message = "Product not found" });
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _repository.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            var existingProduct = _repository.GetById(id);
            if (existingProduct == null) return NotFound(new { message = "Product not found" });

            product.Id = id;
            _repository.Update(product);
            return Ok(product);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound(new { message = "Product not found" });
            _repository.Delete(id);
            return NoContent();
        }



    }
}
