using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Contracts;
using OnlineTestSystem.Api.Models.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;

        public CategoryController(IMapper mapper, ITestRepository testRepository)
        {
            _mapper = mapper;
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAssignedCategories()
        {
            var tests = await _testRepository.GetAssignedTests(User.Identity.Name);
            var categories = tests.Select(t => t.Category).Distinct();
            var distinctCategories = new List<Category>();
            foreach (var cat in categories)
            {
                if (distinctCategories.FirstOrDefault(c => c.CategoryId == cat.CategoryId) == null)
                    distinctCategories.Add(cat);
            }
            var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResponse>>(distinctCategories);
            return Ok(result);
        }
    }
}
