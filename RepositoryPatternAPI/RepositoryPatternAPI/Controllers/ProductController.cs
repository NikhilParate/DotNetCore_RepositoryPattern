using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternAPI.Entity;
using RepositoryPatternAPI.Repository;
using RepositoryPatternAPI.ViewModel;

namespace RepositoryPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);    
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var products = await _productRepository.GetByIdAsync(id);
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductRequest product)
        {
            var productEntity = new Product() { ProductName = product.ProductName, Price = product.Price };

            var createProductResponse = await _productRepository.AddAsync(productEntity);
            return CreatedAtAction(nameof(GetById), new {id = createProductResponse.ProductId}, createProductResponse);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductRequest product)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if(productEntity == null)
            {
                return NotFound();
            }

            productEntity.ProductName = product.ProductName;
            productEntity.Price = product.Price;
            await _productRepository.UpdateAsync(productEntity);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(product);
            return NoContent();
        }
    }
}
