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
    public class MenuController : ControllerBase
    {
        #region props
        private static ILogger _logger;
        private readonly IMenuBo _menuBo;
        #endregion

        #region constructor
        public MenuController(IMenuBo menuBo)
        {
            _menuBo = menuBo ??
                throw new ArgumentNullException("_menuBo", "_menuBo can not be null");
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<MenuEntity>> GetMenusAsync()
        {
            try
            {
                return await _menuBo.ListMenu();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [HttpPost("add")]
        public async Task<StatusCodeResult> AddMenuAsync(MenuDto menuDto)
        {

            try
            {
                if (menuDto == null)
                    throw new ArgumentNullException("menuDto", "menuDto can not be null");

                await _menuBo.AddMenu(
                   menuDto);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public async Task UpdateMenuAsync(MenuEntity menuEntity)
        {
            try
            {
                await _menuBo.UpdateMenu(menuEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete("{menuId}")]
        public async Task DeleteMenuAsync(string menuId)
        {
            try
            {
                await _menuBo.DeleteMenuById(menuId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet("{menuId}")]
        public async Task<MenuEntity> GetMenuAsync(string menuId)
        {
            try
            {
                return await _menuBo.GetMenuById(menuId);
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