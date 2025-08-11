using HarmanKnowledgeHubPortal.Data;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace HarmanKnowledgeHubPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add controllers & Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ✅ Register all YOUR modules
            builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
            builder.Services.AddScoped<IDashboardService, DashboardService>();
            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Register DbContext with a connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}