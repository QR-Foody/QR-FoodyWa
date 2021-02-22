using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public interface IProductEntityDataStorage : IEntityDataStore<string, ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> ListAsync();
    }
}