
using EducationApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Domain
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly ILogger<AppDbContext> _logger;

        public AppDbContext(IConfiguration configuration, ILogger<AppDbContext> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string is empty.");
            _logger = logger;
        }
        //configuring db connection and provider settings for the DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseNpgsql(_connectionString, x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name));
                base.OnConfiguring(optionsBuilder);
            }
            else
            {
                throw new ArgumentNullException(nameof(_connectionString), "Connection string is empty.");
            }
        }

        //dbsets entities  

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
       // public DbSet<Category> Categories { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserRatingReview> UserRatingReviews { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}