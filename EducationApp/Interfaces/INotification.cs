namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int id);
        Task<Notification> CreateNotificationAsync(Notification notification);
        Task<bool> UpdateNotificationAsync(int id, Notification notification);
        Task<bool> DeleteNotificationAsync(int id);
    }

}
