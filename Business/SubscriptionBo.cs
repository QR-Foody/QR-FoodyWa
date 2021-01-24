using Business.Dtos;
using DataAccess.DataStorage;
using DataAccess.Entities;
using System;
using System.Threading.Tasks;

namespace Business
{
    public class SubscriptionBo : ISubscriptionBo
    {
        private readonly ISubscriptionEntityDataStorage _subscriptionEntityDataStorage;

        public SubscriptionBo(ISubscriptionEntityDataStorage subscriptionEntityDataStorage)
        {
            _subscriptionEntityDataStorage = subscriptionEntityDataStorage ??
                throw new ArgumentException("_subscriptionEntityDataStorage", "_subscriptionEntityDataStorage can not be null");
        }

        public async Task AddSubscription(SubscriptionDto subscriptionDto) 
        {
            var subscriptionEntity =
                new SubscriptionEntity
                {
                    Name = subscriptionDto.Name,
                    Cost = subscriptionDto.Cost,
                };

            await _subscriptionEntityDataStorage.AddAsync(
                subscriptionEntity);
        }
    }
}
