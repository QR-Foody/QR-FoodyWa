using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public interface ISubmenuEntityDataStorage : IEntityDataStore<string, SubmenuEntity>
    {
        Task<IEnumerable<SubmenuEntity>> ListAsync();
    }
}