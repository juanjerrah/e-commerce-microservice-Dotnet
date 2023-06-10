using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/Catalog/Product")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            await _productRepository.GetProductsAsync();
            return Ok();
        }

        [HttpGet]
        [Route("ProductById")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = _productRepository.GetProductByIdAsync(id);

            if (product is null)
                return NotFound();
            
            return Ok(product);
        }

        [HttpGet]
        [Route("ProductByName")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var product = _productRepository.GetProductsByNameAsync(name);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("ProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var product = _productRepository.GetProductsByCategory(category);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> InsertProduct(Product product)
        {
            if (product is null)
                return BadRequest("Invalid product");

            await _productRepository.CreateProductAsync(product);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> UpdateProduct(Product product)
        {
            if (product is null)
                return BadRequest("Invalid product");

            var wasUpdated = await _productRepository.UpdateProductAsync(product);

            return wasUpdated ? Ok(wasUpdated) : BadRequest(wasUpdated);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]

        public async Task<ActionResult> DeleteProduct(string id)
        {
            if (id is null)
                return BadRequest("Invalid identifier");

            var wasDeleted = await _productRepository.DeleteProductAsync(id);

            return wasDeleted ? Ok(wasDeleted) : BadRequest(wasDeleted);
        }
    }
}
