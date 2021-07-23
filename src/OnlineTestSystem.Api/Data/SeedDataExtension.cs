using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineTestSystem.Api.Models;
using System.Collections.Generic;
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
            using (var scope = app.ApplicationServices.CreateScope())
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

                if (await context.Tests.CountAsync() == 0)
                {
                    var tests = await CreateSeedData(configuration, userManager);
                    await context.Tests.AddRangeAsync(tests);
                    await context.SaveChangesAsync();
                }
            }
        } 
        
        private async static Task<IEnumerable<Test>> CreateSeedData(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            var username1 = configuration["SeedData:TestUser1:Username"];
            var user1 = await userManager.FindByNameAsync(username1);
            var username2 = configuration["SeedData:TestUser2:Username"];
            var user2 = await userManager.FindByNameAsync(username2);

            var mathCategory = new Category { Name = "Math" };
            var user1Category = new Category { Name = "User1Category" };
            var user2Category = new Category { Name = "User2Category" };

            var mathTest = new Test
            {
                Category = mathCategory,
                Description = "Test for both users. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam",
                Title = "Math test",
                Questions = new List<TestQuestion>
                {
                    new TestQuestion
                    {
                        Question = "First question. consectetur adipiscing elit, sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 2
                    },
                    new TestQuestion
                    {
                        Question = "Second question. sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do " },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 4
                    },
                    new TestQuestion
                    {
                        Question = "Third question. incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 1
                    },
                    new TestQuestion
                    {
                        Question = "Fourth question. consectetur adipismod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                        },
                        CorrectOptions = 3
                    },
                    new TestQuestion
                    {
                        Question = "Fifth question. consectetur adipiscing elit, sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                        },
                        CorrectOptions = 1
                    }
                }
            };
            mathTest.ApplicationUsers = new List<ApplicationUser>();
            mathTest.ApplicationUsers.Add(user1);
            mathTest.ApplicationUsers.Add(user2);
            mathCategory.Tests = new List<Test> { mathTest };

            var user1Test = new Test
            {
                Category = user1Category,
                Description = "Test for first user. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor",
                Title = "Test for first user",
                Questions = new List<TestQuestion>
                {
                    new TestQuestion
                    {
                        Question = "First question. consectetur adipiscing elit, sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 2
                    },
                    new TestQuestion
                    {
                        Question = "Second question. sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do " },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 1
                    },
                    new TestQuestion
                    {
                        Question = "Third question. incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 3
                    },
                    new TestQuestion
                    {
                        Question = "Fourth question. consectetur adipismod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                        },
                        CorrectOptions = 1
                    },
                }
            };
            user1Test.ApplicationUsers = new List<ApplicationUser> { user1 };
            user1Category.Tests = new List<Test> { user1Test };

            var user2Test = new Test
            {
                Category = user2Category,
                Description = "Test for second user. sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam",
                Title = "Test for second user",
                Questions = new List<TestQuestion>
                {
                    new TestQuestion
                    {
                        Question = "First question. consectetur adipiscing elit, sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                        },
                        CorrectOptions = 3
                    },
                    new TestQuestion
                    {
                        Question = "Second question. sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do " },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 1
                    },
                    new TestQuestion
                    {
                        Question = "Third question. incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. do" },
                        },
                        CorrectOptions = 3
                    },
                    new TestQuestion
                    {
                        Question = "Fourth question. consectetur adipismod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                            new TestQuestion.Option { Value = "Option 4. sed do" },
                        },
                        CorrectOptions = 1
                    },
                    new TestQuestion
                    {
                        Question = "Fifth question. consectetur adipiscing elit, sed do eiusmod tempor incididunt?",
                        Options = new TestQuestion.Option[]
                        {
                            new TestQuestion.Option { Value = "Option 1. sed do eiusmod" },
                            new TestQuestion.Option { Value = "Option 2. do eiusmod" },
                            new TestQuestion.Option { Value = "Option 3. sed do" },
                        },
                        CorrectOptions = 2
                    }
                }
            };
            user2Test.ApplicationUsers = new List<ApplicationUser> { user2 };
            user2Category.Tests = new List<Test> { user2Test };

            return new Test[] { mathTest, user1Test, user2Test};
        }
    }
}
