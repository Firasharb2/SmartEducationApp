namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISocialAccountService
    {
        Task<IEnumerable<SocialAccount>> GetSocialAccountsAsync();
        Task<SocialAccount> GetSocialAccountByIdAsync(int id);
        Task<SocialAccount> CreateSocialAccountAsync(SocialAccount socialAccount);
        Task<bool> UpdateSocialAccountAsync(int id, SocialAccount socialAccount);
        Task<bool> DeleteSocialAccountAsync(int id);
    }

}
