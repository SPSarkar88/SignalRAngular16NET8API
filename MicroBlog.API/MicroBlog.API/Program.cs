using MicroBlog.API.AppDbContext;
using MicroBlog.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AddServices(builder);

            var app = builder.Build();

            Run(app);
        }

        private static void Run(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                CreateDbIfNotExists(app);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddSqliteDbServices();
            builder.Services.AddRepositoryServices();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        private static void CreateDbIfNotExists(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var context = serviceScope
                .ServiceProvider
                .GetService<BlogDbContext>();

            context.Database.EnsureCreated();
        }

    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqliteDbServices(this IServiceCollection services)
        {
            services.AddDbContext<BlogDbContext>(options =>
                           options.UseSqlite("Data Source=./Data/blog.db"));
            return services;
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "MicroBlog.API", Version = "v1" });
            });
            return services;
        }

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
    }
}


