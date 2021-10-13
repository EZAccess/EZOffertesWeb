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
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoriesController(IProductCategoryRepository ProductCategoryRepository)
        {
            this.productCategoryRepository = ProductCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductCategories()
        {
            try
            {
                return Ok(await productCategoryRepository.GetProductCategories());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            try
            {
                var result = await productCategoryRepository.GetProductCategory(id);
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

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> CreateProductCategory(ProductCategory ProductCategory)
        {
            try
            {
                if (ProductCategory == null)
                {
                    return BadRequest();
                }

                var createdProductCategory = await productCategoryRepository.AddProductCategory(ProductCategory);
                return CreatedAtAction(nameof(GetProductCategory), new { id = createdProductCategory.ProductCategoryId }, createdProductCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductCategory>> UpdateProductCategory(ProductCategory productCategory)
        {
            try
            {
                var ProductCategoryToUpdate = await productCategoryRepository.GetProductCategory(productCategory.ProductCategoryId);
                if (ProductCategoryToUpdate == null)
                {
                    return NotFound($"ProductCategory with id = {productCategory.ProductCategoryId} not found");
                }

                return await productCategoryRepository.UpdateProductCategory(productCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory(int id)
        {
            try
            {
                var ProductCategoryToDelete = await productCategoryRepository.GetProductCategory(id);
                if (ProductCategoryToDelete == null)
                {
                    return NotFound($"ProductCategory with id = {id} not found");
                }

                return await productCategoryRepository.DeleteProductCategory(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
