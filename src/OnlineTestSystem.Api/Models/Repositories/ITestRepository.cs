using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Models.Contracts
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<IEnumerable<Test>> GetAssignedTests(string username);
        Task<IEnumerable<Test>> GetAssignedTests(string categoryName, string username);
    }
}
