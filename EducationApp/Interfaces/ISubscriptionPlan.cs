namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubscriptionPlanService
    {
        Task<IEnumerable<SubscriptionPlan>> GetSubscriptionPlansAsync();
        Task<SubscriptionPlan> GetSubscriptionPlanByIdAsync(int id);
        Task<SubscriptionPlan> CreateSubscriptionPlanAsync(SubscriptionPlan subscriptionPlan);
        Task<bool> UpdateSubscriptionPlanAsync(int id, SubscriptionPlan subscriptionPlan);
        Task<bool> DeleteSubscriptionPlanAsync(int id);
    }

}
