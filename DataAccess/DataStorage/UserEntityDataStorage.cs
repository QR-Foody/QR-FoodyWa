using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public class UserEntityDataStorage : EntityDataStore<string, UserEntity>, IUserEntityDataStorage
    {
        public UserEntityDataStorage(
            EntityDataStoreOptions entityDataStoreOptions) : base("users", entityDataStoreOptions)
        {
        }

        public async Task<IEnumerable<UserEntity>> ListAsync()
        {
            var query =
                "Object eq 'User'";

            return await base.ListAsync(query);
        }
    }
}
