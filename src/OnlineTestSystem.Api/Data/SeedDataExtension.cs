using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineTestSystem.Api.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<ApplicationContext>();
                var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                var configuration = service.GetRequiredService<IConfiguration>();
                var environment = service.GetRequiredService<IHostEnvironment>();

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

                if (await context.Tests.CountAsync() == 0)
                {
                    var tests = await CreateSeedData(configuration, environment, userManager);
                    await context.Tests.AddRangeAsync(tests);
                    await context.SaveChangesAsync();
                }
            }
        } 
        
        private async static Task<IEnumerable<Test>> CreateSeedData(IConfiguration configuration, IHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            var username1 = configuration["SeedData:TestUser1:Username"];
            var user1 = await userManager.FindByNameAsync(username1);
            var username2 = configuration["SeedData:TestUser2:Username"];
            var user2 = await userManager.FindByNameAsync(username2);

            var mathCategory = new Category { Name = "Math" };
            var user1Category = new Category { Name = "User1Category" };
            var user2Category = new Category { Name = "User2Category" };


            var tests = new List<Test>();
            using (var sr = new StreamReader(env.ContentRootPath + "/SeedData.json"))
            {
                var text = await sr.ReadToEndAsync();
                tests = JsonSerializer.Deserialize<List<Test>>(text);
            }

            if (tests.Count != 0)
            {
                tests[0].Category = mathCategory;
                tests[0].ApplicationUsers = new List<ApplicationUser>();
                tests[0].ApplicationUsers.Add(user1);
                tests[0].ApplicationUsers.Add(user2);
                mathCategory.Tests = new List<Test> { tests[0] };

                tests[1].Category = user1Category;
                tests[1].ApplicationUsers = new List<ApplicationUser> { user1 };
                user1Category.Tests = new List<Test> { tests[1] };

                tests[2].Category = user2Category;
                tests[2].ApplicationUsers = new List<ApplicationUser> { user2 };
                user2Category.Tests = new List<Test> { tests[2] };
            }
            return tests;
        }
    }
}
