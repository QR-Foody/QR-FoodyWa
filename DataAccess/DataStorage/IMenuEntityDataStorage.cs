using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public interface IMenuEntityDataStorage : IEntityDataStore<string, MenuEntity>
    {
        Task<IEnumerable<MenuEntity>> ListAsync();
    }
}