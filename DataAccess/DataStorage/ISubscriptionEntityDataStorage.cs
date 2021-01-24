using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public interface ISubscriptionEntityDataStorage : IEntityDataStore<string, SubscriptionEntity>
    {
        Task<IEnumerable<SubscriptionEntity>> ListAsync();
    }
}