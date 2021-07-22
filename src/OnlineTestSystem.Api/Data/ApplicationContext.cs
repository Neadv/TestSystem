using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineTestSystem.Api.Models;

namespace OnlineTestSystem.Api.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) 
            : base(contextOptions) { }
    }
}
