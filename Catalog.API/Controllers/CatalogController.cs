using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepo,ILogger<CatalogController> logger)
        {
            _productRepo = productRepo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProducts()
        {
            var products = await _productRepo.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}" , Name = "GetProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _productRepo.GetProduct(id);
            if(product==null)
            {
                _logger.LogError($"Product with id:{id},not found");
                return NotFound();
            }
            return Ok(product);
        }

        [Route("[action]/{CategoryName}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductByCategory(string CategoryName)
        {
            var products = await _productRepo.GetProductsByCategory(CategoryName);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product prod)
        {
            await _productRepo.Create(prod);
            return CreatedAtRoute("GetProduct", new { id = prod.Id }, prod);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product prod)
        {
            return Ok(await _productRepo.Update(prod));

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Delete(string Id)
        {
            return Ok(await _productRepo.Delete(Id));

        }
    }
}
