using Business.Dtos;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductBo
    {
        Task AddProduct(ProductDto productDto);

        Task DeleteProductById(string productId);

        Task UpdateProduct(ProductEntity productEntity);

        Task<IEnumerable<ProductEntity>> ListProduct();

        Task<ProductEntity> GetProductById(string productId);
    }
}
