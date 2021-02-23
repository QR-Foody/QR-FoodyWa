using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public class SubmenuEntityDataStorage : EntityDataStore<string, SubmenuEntity>, ISubmenuEntityDataStorage
    {
        public SubmenuEntityDataStorage(
            EntityDataStoreOptions entityDataStoreOptions) : base("submenus", entityDataStoreOptions)
        {
        }

        public async Task<IEnumerable<SubmenuEntity>> ListAsync()
        {
            var query =
                "Object eq 'Submenu'";

            return await base.ListAsync(query);
        }
    }
}
