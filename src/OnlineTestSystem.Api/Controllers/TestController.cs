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
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
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
    }
}
