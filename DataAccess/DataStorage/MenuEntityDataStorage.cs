using DataAccess.Entities;
using DataAccess.StorageTableRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataStorage
{
    public class MenuEntityDataStorage : EntityDataStore<string, MenuEntity>, IMenuEntityDataStorage
    {
        public MenuEntityDataStorage(
            EntityDataStoreOptions entityDataStoreOptions) : base("menus", entityDataStoreOptions)
        {
        }

        public async Task<IEnumerable<MenuEntity>> ListAsync()
        {
            var query =
                "Object eq 'Menu'";

            return await base.ListAsync(query);
        }
    }
}
