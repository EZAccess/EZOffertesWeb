using EZOffertes.Models;
using EZOffertes.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EZOffertes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository ProductRepository)
        {
            this.productRepository = ProductRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await productRepository.GetProduct(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await productRepository.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product Product)
        {
            try
            {
                if (Product == null)
                {
                    return BadRequest();
                }

                var createdProduct = await productRepository.AddProduct(Product);
                return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product Product)
        {
            try
            {
                var ProductToUpdate = await productRepository.GetProduct(Product.ProductId);
                if (ProductToUpdate == null)
                {
                    return NotFound($"Product with id = {Product.ProductId} not found");
                }

                return await productRepository.UpdateProduct(Product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var ProductToDelete = await productRepository.GetProduct(id);
                if (ProductToDelete == null)
                {
                    return NotFound($"Product with id = {id} not found");
                }

                return await productRepository.DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
