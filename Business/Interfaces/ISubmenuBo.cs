using Business.Dtos;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISubmenuBo
    {
        Task AddSubmenu(SubmenuDto submenuDto);

        Task DeleteSubmenuById(string submenuId);

        Task UpdateSubmenu(SubmenuEntity submenuEntity);

        Task<IEnumerable<SubmenuEntity>> ListSubmenu();

        Task<SubmenuEntity> GetSubmenuById(string submenuId);
    }
}