using Business.Dtos;
using DataAccess.DataStorage;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public class ProductBo : IProductBo
    {
        private readonly IProductEntityDataStorage _productEntityDataStorage;

        public ProductBo(IProductEntityDataStorage productEntityDataStorage)
        {
            _productEntityDataStorage = productEntityDataStorage ??
                throw new ArgumentException("_productEntityDataStorage", "_productEntityDataStorage can not be null");
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var productEntity =
                new ProductEntity
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    ImageUri = productDto.ImageUri
                };

            await _productEntityDataStorage.AddAsync(
                productEntity);
        }

        public async Task DeleteProductById(string productId)
        {

            if (string.IsNullOrEmpty(productId))
                throw new ArgumentNullException();

            await _productEntityDataStorage
                            .DeleteByIdAsync(productId);

        }

        public async Task UpdateProduct(ProductEntity productEntity)
        {
            await _productEntityDataStorage
                            .UpdateAsync(productEntity);
        }

        public async Task<IEnumerable<ProductEntity>> ListProduct()
        {
            return await _productEntityDataStorage.ListAsync();
        }

        public async Task<ProductEntity> GetProductById(string productId)
        {

            if (string.IsNullOrEmpty(productId))
                throw new ArgumentNullException();

            return await _productEntityDataStorage.GetByIdAsync(productId);
        }
    }
}
