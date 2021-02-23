using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Interfaces;
using DataAccess.DataStorage;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRFoodyWa.Helpers;

namespace QRFoodyWa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ProductController : ControllerBase
    {
        #region props
        private static ILogger _logger;
        private readonly IProductBo _productBo;
        #endregion

        #region constructor
        public ProductController(IProductBo productBo)
        {
            _productBo = productBo ??
                throw new ArgumentNullException("_productBo", "_productBo can not be null");
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<ProductEntity>> GetProductsAsync()
        {
            try
            {
                return await _productBo.ListProduct();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [HttpPost("add")]
        public async Task<StatusCodeResult> AddProductAsync(ProductDto productDto)
        {

            try
            {
                if (productDto == null)
                    throw new ArgumentNullException("productDto", "productDto can not be null");

                await _productBo.AddProduct(
                   productDto);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public async Task UpdateProductAsync(ProductEntity productEntity)
        {
            try
            {
                await _productBo.UpdateProduct(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete("{productId}")]
        public async Task DeleteProductAsync(string productId)
        {
            try
            {
                await _productBo.DeleteProductById(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet("{productId}")]
        public async Task<ProductEntity> GetProductAsync(string productId)
        {
            try
            {
                return await _productBo.GetProductById(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
