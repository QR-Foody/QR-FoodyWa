using Business.Dtos;
using DataAccess.DataStorage;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public class UserBo : IUserBo
    {
        private readonly IUserEntityDataStorage _userEntityDataStorage;

        public UserBo(IUserEntityDataStorage userEntityDataStorage)
        {
            _userEntityDataStorage = userEntityDataStorage ??
                throw new ArgumentException("_userEntityDataStorage", "_userEntityDataStorage can not be null");
        }

        public async Task AddUser(UserDto userDto)
        {
            var userEntity =
                new UserEntity
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    UserName = userDto.UserName,
                    BirthDate = userDto.BirthDate,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    SubscriptionId = userDto.SubscriptionId               
                };

            await _userEntityDataStorage.AddAsync(
                userEntity);
        }

        public async Task DeleteUserById(string userId)
        {

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException();

            await _userEntityDataStorage
                            .DeleteByIdAsync(userId);

        }

        public async Task UpdateUser(UserEntity userEntity)
        {
            await _userEntityDataStorage
                            .UpdateAsync(userEntity);
        }

        public async Task<IEnumerable<UserEntity>> ListUser()
        {
            return await _userEntityDataStorage.ListAsync();
        }

        public async Task<UserEntity> GetUserById(string userId)
        {

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException();

            return await _userEntityDataStorage.GetByIdAsync(userId);
        }
    }
}
