using Business.Dtos;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMenuBo
    {
        Task AddMenu(MenuDto menuDto);

        Task DeleteMenuById(string menuId);

        Task UpdateMenu(MenuEntity menuEntity);

        Task<IEnumerable<MenuEntity>> ListMenu();

        Task<MenuEntity> GetMenuById(string menuId);
    }
}