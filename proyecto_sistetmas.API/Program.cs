
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Api.Helpers;
using proyecto_sistemas.Shared.Entities;

namespace proyecto_sistetmas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=con"));
            builder.Services.AddScoped<IUserHelper, UserHelper>();
            builder.Services.AddTransient<Seeder>();
            builder.Services.AddIdentity<User, IdentityRole>(
                x =>
                {
                    x.User.RequireUniqueEmail = true;
                    x.Password.RequireUppercase = true;
                    x.Password.RequiredLength = 10;
                    x.Password.RequireLowercase = true;
                    x.Password.RequireNonAlphanumeric = true;
                    x.Password.RequireDigit = false;
                    x.Password.RequiredUniqueChars = 6;
                }

                );

            var app = builder.Build();
            SeedApp(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void SeedApp(WebApplication app)
        {
            IServiceScopeFactory? serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using (IServiceScope? serviceScope = serviceScopeFactory.CreateScope())
            {
                Seeder? seeder = serviceScope.ServiceProvider.GetService<Seeder>();
                seeder!.SeedAsync().Wait();

            }
        }
    }
}
