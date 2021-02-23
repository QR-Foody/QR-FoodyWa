using Business.Dtos;
using DataAccess.DataStorage;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public class SubmenuBo : ISubmenuBo
    {
        private readonly ISubmenuEntityDataStorage _submenuEntityDataStorage;

        public SubmenuBo(ISubmenuEntityDataStorage submenuEntityDataStorage)
        {
            _submenuEntityDataStorage = submenuEntityDataStorage ??
                throw new ArgumentException("_submenuEntityDataStorage", "_submenuEntityDataStorage can not be null");
        }

        public async Task AddSubmenu(SubmenuDto submenuDto)
        {
            var submenuEntity =
                new SubmenuEntity
                {
                    Name = submenuDto.Name,
                    Description = submenuDto.Description,
                    
                };

            await _submenuEntityDataStorage.AddAsync(
                submenuEntity);
        }

        public async Task DeleteSubmenuById(string submenuId)
        {

            if (string.IsNullOrEmpty(submenuId))
                throw new ArgumentNullException();

            await _submenuEntityDataStorage
                            .DeleteByIdAsync(submenuId);

        }

        public async Task UpdateSubmenu(SubmenuEntity submenuEntity)
        {
            await _submenuEntityDataStorage
                            .UpdateAsync(submenuEntity);
        }

        public async Task<IEnumerable<SubmenuEntity>> ListSubmenu()
        {
            return await _submenuEntityDataStorage.ListAsync();
        }

        public async Task<SubmenuEntity> GetSubmenuById(string submenuId)
        {

            if (string.IsNullOrEmpty(submenuId))
                throw new ArgumentNullException();

            return await _submenuEntityDataStorage.GetByIdAsync(submenuId);
        }
    }
}
