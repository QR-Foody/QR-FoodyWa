using Business.Dtos;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISubscriptionBo
    {
        Task AddSubscription(SubscriptionDto subscriptionDto);

        Task DeleteSubscriptionById(string subscriptionId);

        Task UpdateSubscriptionById(SubscriptionEntity subscriptionEntity);

        Task<IEnumerable<SubscriptionEntity>> ListSusbscription();

        Task<SubscriptionEntity> GetSubscriptionById(string subscriptionId);

    }
}