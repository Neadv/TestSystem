using Microsoft.EntityFrameworkCore;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Data.Contracts
{
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(ApplicationContext context) 
            : base(context) { }

        public async Task<IEnumerable<Test>> GetAssignedTests(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"\"{nameof(username)}\" can't be undefined or empty.", nameof(username));
            }

            return await Set.Include(t => t.ApplicationUsers)
                .Where(t => t.ApplicationUsers.FirstOrDefault(u => u.UserName == username) != null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Test>> GetAssignedTests(string categoryName, string username)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentException($"\"{nameof(categoryName)}\" can't be undefined or empty.", nameof(categoryName));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"\"{nameof(username)}\" can't be undefined or empty.", nameof(username));
            }

            return await Set
                .Include(t => t.ApplicationUsers)
                .Include(t => t.Category)
                .Where(t => t.Category.Name == categoryName && t.ApplicationUsers.FirstOrDefault(u => u.UserName == username) != null)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
