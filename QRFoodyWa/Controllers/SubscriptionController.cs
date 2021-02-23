using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business;
using Business.Dtos;
using Business.Interface;
using DataAccess.DataStorage;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRFoodyWa.Helpers;

namespace QRFoodyWa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKey]
    public class SubscriptionController : ControllerBase
    {
        #region props
        private static ILogger _logger;
        private readonly ISubscriptionBo _subscriptionBo;
        #endregion

        #region constructor
        public SubscriptionController(ISubscriptionBo subscriptionBo) {
            _subscriptionBo = subscriptionBo ??
                throw new ArgumentNullException("_subscriptionBo", "_subscriptionBo can not be null");
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<SubscriptionEntity>> GetSubscriptionsAsync()
        {
            try
            {
                return await _subscriptionBo.ListSusbscription();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [HttpPost("add")]
        public async Task<StatusCodeResult> AddSubscriptionAsync(SubscriptionDto subscriptionDto)
        {

            try
            {
                if (subscriptionDto == null)
                    throw new ArgumentNullException("subscriptionDto", "subscriptionDto can not be null");

                await _subscriptionBo.AddSubscription(
                   subscriptionDto);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public async Task UpdateSubscriptionAsync(SubscriptionEntity subscriptionEntity)
        {
            try
            {
                await _subscriptionBo.UpdateSubscriptionById(subscriptionEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete("{subscriptionId}")]
        public async Task DeleteSubscriptionAsync(string subscriptionId)
        {
            try
            {
                await _subscriptionBo.DeleteSubscriptionById(subscriptionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet("{subscriptionId}")]
        public async Task<SubscriptionEntity> GetSubscriptionAsync(string subscriptionId)
        {
            try
            {
                return await _subscriptionBo.GetSubscriptionById(subscriptionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }
        #endregion

    }
}