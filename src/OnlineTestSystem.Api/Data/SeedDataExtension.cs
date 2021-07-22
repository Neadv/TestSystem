using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineTestSystem.Api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Data
{
    public static class SeedDataExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            SeedDataAsync(app).GetAwaiter().GetResult();
        }

        public async static Task SeedDataAsync(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<ApplicationContext>();
                var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                var configuration = service.GetRequiredService<IConfiguration>();

                await context.Database.MigrateAsync();

                if (await context.Users.CountAsync() == 0)
                {
                    var user1 = new ApplicationUser()
                    {
                        UserName = configuration["SeedData:TestUser1:Username"],
                    };
                    var password = configuration["SeedData:TestUser1:Password"];
                    await userManager.CreateAsync(user1, password);

                    var user2 = new ApplicationUser()
                    {
                        UserName = configuration["SeedData:TestUser2:Username"],
                    };
                    password = configuration["SeedData:TestUser2:Password"];
                    await userManager.CreateAsync(user2, password);
                }
            }
        }        
    }
}
