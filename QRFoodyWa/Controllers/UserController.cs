using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRFoodyWa.Helpers;

namespace QRFoodyWa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UserController : ControllerBase
    {
        #region props
        private static ILogger _logger;
        private readonly IUserBo _userBo;
        #endregion

        #region constructor
        public UserController(IUserBo userBo)
        {
            _userBo = userBo ??
                throw new ArgumentNullException("_userBo", "_userBo can not be null");
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            try
            {
                return await _userBo.ListUser();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [HttpPost("add")]
        public async Task<StatusCodeResult> AddUserAsync(UserDto userDto)
        {

            try
            {
                if (userDto == null)
                    throw new ArgumentNullException("userDto", "userDto can not be null");

                await _userBo.AddUser(
                   userDto);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public async Task UpdateUserAsync(UserEntity userEntity)
        {
            try
            {
                await _userBo.UpdateUser(userEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete("{userId}")]
        public async Task DeleteUserAsync(string userId)
        {
            try
            {
                await _userBo.DeleteUserById(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet("{userId}")]
        public async Task<UserEntity> GetUserAsync(string userId)
        {
            try
            {
                return await _userBo.GetUserById(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}