using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public class SubscriptionEntityDataStorage : EntityDataStore<string, SubscriptionEntity>, ISubscriptionEntityDataStorage
    {
        public SubscriptionEntityDataStorage(
            EntityDataStoreOptions entityDataStoreOptions) : base("subscriptions", entityDataStoreOptions)
        {
        }

        public async Task<IEnumerable<SubscriptionEntity>> ListAsync()
        {
            var query =
                "Object eq 'Subsription'";

            return await base.ListAsync(query);
        }
    }
}
