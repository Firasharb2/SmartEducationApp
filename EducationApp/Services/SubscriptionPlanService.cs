namespace EducationApp.Services
{
    using EducationApp.Domain;
    using EducationApp.Domain.Models;
    using EducationApp.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly AppDbContext _context;

        public SubscriptionPlanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionPlan>> GetSubscriptionPlansAsync()
        {
            return await _context.SubscriptionPlans.ToListAsync();
        }

        public async Task<SubscriptionPlan> GetSubscriptionPlanByIdAsync(int id)
        {
            return await _context.SubscriptionPlans.FindAsync(id);
        }

        public async Task<SubscriptionPlan> CreateSubscriptionPlanAsync(SubscriptionPlan subscriptionPlan)
        {
            _context.SubscriptionPlans.Add(subscriptionPlan);
            await _context.SaveChangesAsync();
            return subscriptionPlan;
        }

        public async Task<bool> UpdateSubscriptionPlanAsync(int id, SubscriptionPlan subscriptionPlan)
        {
            if (id != subscriptionPlan.SubscriptionPlanId)
            {
                return false;
            }

            _context.Entry(subscriptionPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSubscriptionPlanAsync(int id)
        {
            var subscriptionPlan = await _context.SubscriptionPlans.FindAsync(id);
            if (subscriptionPlan == null)
            {
                return false;
            }

            _context.SubscriptionPlans.Remove(subscriptionPlan);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
