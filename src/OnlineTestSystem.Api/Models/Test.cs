using System.Collections.Generic;

namespace OnlineTestSystem.Api.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<TestQuestion> Questions { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
