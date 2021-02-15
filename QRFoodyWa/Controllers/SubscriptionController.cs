using System;
using Business;
using Business.Dtos;
using DataAccess.DataStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace QRFoodyWa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private static ILogger _logger;
        private readonly ISubscriptionEntityDataStorage _subscriptionEntityDataStorage;
        private readonly ISubscriptionBo _subscriptionBo;

        public SubscriptionController(ISubscriptionEntityDataStorage subscriptionEntityDataStorage,
            ISubscriptionBo subscriptionBo) {
            _subscriptionEntityDataStorage = subscriptionEntityDataStorage ??
                throw new ArgumentException("_subscriptionEntityDataStorage", "_subscriptionEntityDataStorage can not be null");
            _subscriptionBo = subscriptionBo ??
                throw new ArgumentNullException("_subscriptionBo", "_subscriptionBo can not be null");
        }

        [HttpPost]
        public StatusCodeResult Run(SubscriptionDto subscriptionDto)
        {

            try
            {
                if (subscriptionDto == null)
                    throw new ArgumentNullException("subscriptionDto", "subscriptionDto can not be null");

                 _subscriptionBo.AddSubscription(
                    subscriptionDto).Wait();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }

    }
}