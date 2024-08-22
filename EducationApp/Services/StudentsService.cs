using EducationApp.Domain;
using EducationApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text;

namespace EducationApp.Services
{
    public class StudentsService: IStudentsService
    {

        private readonly AppDbContext _appDbContext;

        public StudentsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> GetStudentsCount()
        {
            try
            {
                var ss = await _appDbContext.Students.CountAsync();
                return ss;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        
    }
}
