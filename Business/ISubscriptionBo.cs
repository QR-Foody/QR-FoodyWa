using Business.Dtos;
using System.Threading.Tasks;

namespace Business
{
    public interface ISubscriptionBo
    {
        Task AddSubscription(SubscriptionDto subscriptionDto);
    }
}