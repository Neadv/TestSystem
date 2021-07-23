using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Contracts;
using OnlineTestSystem.Api.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper, IQuestionsRepository questionsRepository)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _questionsRepository = questionsRepository;
        }

        [HttpGet("assigned")]
        public async Task<ActionResult> GetAssignedTests([FromQuery]string categoryName = null) 
        {
            IEnumerable<Test> tests;
            if (categoryName != null)
                tests = await _testRepository.GetAssignedTests(categoryName, User.Identity.Name);
            else
                tests = await _testRepository.GetAssignedTests(User.Identity.Name);

            var result = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResponse>>(tests);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTest(int id)
        {
            var test = await _testRepository.GetTestById(id, User.Identity.Name);
            if (test != null)
                return Ok(_mapper.Map<Test, TestResponse>(test));
            return NotFound();
        }

        [HttpGet("questions/{id:int}")]
        public async Task<ActionResult> GetQuestions(int id)
        {
            var questions = await _questionsRepository.LoadQuestionsByTest(id);
            var result = _mapper.Map<IEnumerable<TestQuestion>, IEnumerable<QuestionResponse>>(questions);
            return Ok(result);
        }
    }
}
