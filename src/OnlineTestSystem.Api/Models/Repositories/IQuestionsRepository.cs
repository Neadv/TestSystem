using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Models.Contracts
{
    public interface IQuestionsRepository : IRepository<TestQuestion>
    {
        Task<IEnumerable<TestQuestion>> LoadQuestionsByTest(int testId);
    }
}
