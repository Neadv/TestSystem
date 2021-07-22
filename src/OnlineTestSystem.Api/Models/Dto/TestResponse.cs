namespace OnlineTestSystem.Api.Models.Dto
{
    public class TestResponse
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionCount { get; set; }
    }
}
