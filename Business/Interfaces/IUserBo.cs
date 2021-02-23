using Business.Dtos;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserBo
    {
        Task AddUser(UserDto userDto);

        Task DeleteUserById(string userId);

        Task UpdateUser(UserEntity userEntity);

        Task<IEnumerable<UserEntity>> ListUser();

        Task<UserEntity> GetUserById(string userId);
    }
}