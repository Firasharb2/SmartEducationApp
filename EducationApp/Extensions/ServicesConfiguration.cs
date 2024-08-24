using EducationApp.Domain;
using EducationApp.Interfaces;
using EducationApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EducationApp.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("local",
                    builder => builder
                        .WithOrigins("http://127.0.0.1:3000", "http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
            });

            // Authentication configuration
            var tenantAuthority = configuration["Identity:Authority"] ?? string.Empty;

            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", options =>
               {
                   options.Authority = tenantAuthority;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false,
                       ValidateIssuer = false,
                       ValidIssuer = tenantAuthority
                   };
               });

            // Database context configuration for PostgreSQL
            services.AddScoped(sp =>
            {
                var logger = sp.GetService<ILogger<AppDbContext>>();
                return new AppDbContext(configuration, logger);
            });

            // Inject services
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseEnrollmentService, CourseEnrollmentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuizQuestionService, QuizQuestionService>();
            services.AddScoped<IQuizResultService, QuizResultService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
