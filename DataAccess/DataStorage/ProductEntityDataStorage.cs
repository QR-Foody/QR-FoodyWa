using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public class ProductEntityDataStorage : EntityDataStore<string, ProductEntity>, IProductEntityDataStorage
    {
        public ProductEntityDataStorage(
            EntityDataStoreOptions entityDataStoreOptions) : base("products", entityDataStoreOptions)
        {
        }

        public async Task<IEnumerable<ProductEntity>> ListAsync()
        {
            var query =
                "Object eq 'Product'";

            return await base.ListAsync(query);
        }
    }
}
