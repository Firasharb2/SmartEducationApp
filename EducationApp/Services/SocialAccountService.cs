namespace EducationApp.Services
{
    using EducationApp.Domain;
    using EducationApp.Domain.Models;
    using EducationApp.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SocialAccountService : ISocialAccountService
    {
        private readonly AppDbContext _context;

        public SocialAccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SocialAccount>> GetSocialAccountsAsync()
        {
            return await _context.SocialAccounts.ToListAsync();
        }

        public async Task<SocialAccount> GetSocialAccountByIdAsync(int id)
        {
            return await _context.SocialAccounts.FindAsync(id);
        }

        public async Task<SocialAccount> CreateSocialAccountAsync(SocialAccount socialAccount)
        {
            _context.SocialAccounts.Add(socialAccount);
            await _context.SaveChangesAsync();
            return socialAccount;
        }

        public async Task<bool> UpdateSocialAccountAsync(int id, SocialAccount socialAccount)
        {
            if (id != socialAccount.SocialAccountId)
            {
                return false;
            }

            _context.Entry(socialAccount).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSocialAccountAsync(int id)
        {
            var socialAccount = await _context.SocialAccounts.FindAsync(id);
            if (socialAccount == null)
            {
                return false;
            }

            _context.SocialAccounts.Remove(socialAccount);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
