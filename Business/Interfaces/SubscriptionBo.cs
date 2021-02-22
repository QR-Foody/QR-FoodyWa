using Business.Dtos;
using DataAccess.DataStorage;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
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
                    Description = subscriptionDto.Description,
                    Cost = subscriptionDto.Price,
                };

            await _subscriptionEntityDataStorage.AddAsync(
                subscriptionEntity);
        }

        public async Task DeleteSubscriptionById(string subscriptionId)
        {

            if (string.IsNullOrEmpty(subscriptionId))
                await Task.FromResult(false);

            await _subscriptionEntityDataStorage
                            .DeleteByIdAsync(subscriptionId);

        }

        public async Task UpdateSubscriptionById(SubscriptionEntity subscriptionEntity)
        {
            await _subscriptionEntityDataStorage
                            .UpdateAsync(subscriptionEntity);
        }

        public async Task<IEnumerable<SubscriptionEntity>> ListSusbscription() 
        {
           return await _subscriptionEntityDataStorage.ListAsync(); 
        }

        public async Task<SubscriptionEntity> GetSubscriptionById(string subscriptionId) {
            
            if (string.IsNullOrEmpty(subscriptionId))
                await Task.FromResult(false);

            return await _subscriptionEntityDataStorage.GetByIdAsync(subscriptionId);
        }
 
    }
}
