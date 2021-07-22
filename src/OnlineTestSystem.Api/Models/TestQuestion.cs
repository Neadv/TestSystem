using System.Collections.Generic;

namespace OnlineTestSystem.Api.Models
{
    public class TestQuestion
    {
        public int TestQuestionId { get; set; }
        public string Question { get; set; }
        public ICollection<Option> Options { get; set; }
        public int CorrectOptions { get; set; }

        public class Option
        {
            public int OptionId { get; set; }
            public string Value { get; set; }
        }
    }
}
