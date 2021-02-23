using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public interface IUserEntityDataStorage : IEntityDataStore<string, UserEntity>
    {
        Task<IEnumerable<UserEntity>> ListAsync();
    }
}