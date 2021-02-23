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
    public class SubmenuController : ControllerBase
    {
        #region props
        private static ILogger _logger;
        private readonly ISubmenuBo _submenuBo;
        #endregion

        #region constructor
        public SubmenuController(ISubmenuBo submenuBo)
        {
            _submenuBo = submenuBo ??
                throw new ArgumentNullException("_submenuBo", "_submenuBo can not be null");
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<SubmenuEntity>> GetSubmenusAsync()
        {
            try
            {
                return await _submenuBo.ListSubmenu();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [HttpPost("add")]
        public async Task<StatusCodeResult> AddSubmenuAsync(SubmenuDto submenuDto)
        {

            try
            {
                if (submenuDto == null)
                    throw new ArgumentNullException("submenuDto", "submenuDto can not be null");

                await _submenuBo.AddSubmenu(
                   submenuDto);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public async Task UpdateSubmenuAsync(SubmenuEntity submenuEntity)
        {
            try
            {
                await _submenuBo.UpdateSubmenu(submenuEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete("{submenuId}")]
        public async Task DeleteSubmenuAsync(string submenuId)
        {
            try
            {
                await _submenuBo.DeleteSubmenuById(submenuId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet("{submenuId}")]
        public async Task<SubmenuEntity> GetSubmenuAsync(string submenuId)
        {
            try
            {
                return await _submenuBo.GetSubmenuById(submenuId);
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