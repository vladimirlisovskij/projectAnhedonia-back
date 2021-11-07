using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Domain.Interactors;
using projectAnhedonia_back.Presentation.Common;
using projectAnhedonia_back.Presentation.Entities.Dto;
using projectAnhedonia_back.Presentation.Entities.Dto.Article;
using projectAnhedonia_back.Presentation.Entities.Dto.User;
using projectAnhedonia_back.Presentation.Filters;

namespace projectAnhedonia_back.Presentation.Controllers
{   
    [ApiController]
    [CustomExceptionFilter]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestInteractor _testInteractor;
        public TestController(TestInteractor testInteractor)
        {
            _testInteractor = testInteractor;
        }
        
        [HttpPost("allUsers")]
        public async Task<Result<List<UserProfileResponseDto>>> GetAllUsers()
        {
            return await _testInteractor
                .GetAllUsers()
                .MapResult(l => l.Select(u => u.ConvertToPresentationLayer()).ToList())
                .ConvertToResult("all users");
        }
        
        [HttpPost("allPosts")]
        public async Task<Result<List<ArticleViewResponseDto>>> GetAllPosts()
        {
            return await _testInteractor
                .GetAllArticles()
                .MapResult(l => l.Select(p => p.ConvertToPresentationLayer()).ToList())
                .ConvertToResult("all articles");
        }
    }
}
