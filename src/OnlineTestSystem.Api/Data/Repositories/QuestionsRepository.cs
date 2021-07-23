using Microsoft.EntityFrameworkCore;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Data.Contracts
{
    public class QuestionsRepository : BaseRepository<TestQuestion>, IQuestionsRepository
    {
        public QuestionsRepository(ApplicationContext context) 
            : base(context) { }

        public async Task<IEnumerable<TestQuestion>> LoadQuestionsByTest(int testId)
        {
            return await Set.Include(q => q.Options).Where(q => q.TestId == testId).AsNoTracking().ToListAsync();
        }
    }
}
