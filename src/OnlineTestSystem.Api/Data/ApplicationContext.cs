using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineTestSystem.Api.Models;

namespace OnlineTestSystem.Api.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> Questions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) 
            : base(contextOptions) { }
    }
}
