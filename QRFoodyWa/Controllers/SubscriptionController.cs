using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Dtos;
using DataAccess.DataStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace QRFoodyWa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISubscriptionEntityDataStorage _subscriptionEntityDataStorage;
        private readonly ISubscriptionBo _subscriptionBo;

        public SubscriptionController(ILogger logger, ISubscriptionEntityDataStorage subscriptionEntityDataStorage,
            ISubscriptionBo subscriptionBo) {
            _logger = logger ?? 
                throw new ArgumentNullException("_logger","_logger can not be null");
            _subscriptionEntityDataStorage = subscriptionEntityDataStorage ??
                throw new ArgumentException("_subscriptionEntityDataStorage", "_subscriptionEntityDataStorage can not be null");
            _subscriptionBo = subscriptionBo ??
                throw new ArgumentNullException("_subscriptionBo", "_subscriptionBo can not be null");
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> Run([FromBody]SubscriptionDto subscriptionDto)
        {
            _logger.LogInformation($"A new subscription will be added.");
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
                _logger.LogError(ex.ToString(), ex.Message);
                return StatusCode(500);
            }
        }

    }
}