using Business.Dtos;
using DataAccess.DataStorage;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public class MenuBo : IMenuBo
    {
        private readonly IMenuEntityDataStorage _menuEntityDataStorage;

        public MenuBo(IMenuEntityDataStorage menuEntityDataStorage)
        {
            _menuEntityDataStorage = menuEntityDataStorage ??
                throw new ArgumentException("_menuEntityDataStorage", "_menuEntityDataStorage can not be null");
        }

        public async Task AddMenu(MenuDto menuDto)
        {
            var menuEntity =
                new MenuEntity
                {
                    Name = menuDto.Name,
                    Description = menuDto.Description,
                    ExpirationDate = menuDto.ExpirationDate,
                    Active = menuDto.Active
                };

            await _menuEntityDataStorage.AddAsync(
                menuEntity);
        }

        public async Task DeleteMenuById(string menuId)
        {

            if (string.IsNullOrEmpty(menuId))
                throw new ArgumentNullException();

            await _menuEntityDataStorage
                            .DeleteByIdAsync(menuId);

        }

        public async Task UpdateMenu(MenuEntity menuEntity)
        {
            await _menuEntityDataStorage
                            .UpdateAsync(menuEntity);
        }

        public async Task<IEnumerable<MenuEntity>> ListMenu()
        {
            return await _menuEntityDataStorage.ListAsync();
        }

        public async Task<MenuEntity> GetMenuById(string menuId)
        {

            if (string.IsNullOrEmpty(menuId))
                throw new ArgumentNullException();

            return await _menuEntityDataStorage.GetByIdAsync(menuId);
        }
    }
}
