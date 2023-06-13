using AutoMapper;
using Catalog.Api.Dtos.ViewModels;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Catalog.Api.Controllers
{
    [Route("api/Catalog/Product")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CatalogController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("ProductById")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Product>> GetProductById([FromQuery] string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product is null)
                return NotFound();
            
            return Ok(product);
        }

        [HttpGet]
        [Route("ProductByName")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName([FromQuery] string name)
        {
            var product = await _productRepository.GetProductsByNameAsync(name);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("ProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory([FromQuery] string category)
        {
            var product = await _productRepository.GetProductsByCategory(category);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<String>> InsertProduct([FromBody] InsertProductViewModel viewModel)
        {
            var product = new Product(ObjectId.GenerateNewId().ToString(), viewModel.Name, viewModel.Category, 
                viewModel.Description, viewModel.Image, viewModel.Price);

            await _productRepository.CreateProductAsync(product);
            return Ok(product.Id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            if (product is null)
                return BadRequest("Invalid product");

            var wasUpdated = await _productRepository.UpdateProductAsync(product);

            return wasUpdated ? Ok(wasUpdated) : BadRequest(wasUpdated);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteProduct([FromQuery] string id)
        {
            if (id is null)
                return BadRequest("Invalid identifier");

            var wasDeleted = await _productRepository.DeleteProductAsync(id);

            return wasDeleted ? Ok(wasDeleted) : BadRequest(wasDeleted);
        }
    }
}
