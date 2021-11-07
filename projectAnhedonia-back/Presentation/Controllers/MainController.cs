using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Data.Models.Database.Main;
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
    public class MainController : ControllerBase
    {
        private readonly MainDatabaseContext _context;
        private readonly MainDbInteractor _mainDbInteractor;

        public MainController(MainDatabaseContext databaseContext, MainDbInteractor mainDbInteractor)
        {
            _context = databaseContext;
            _mainDbInteractor = mainDbInteractor;
        }

        [HttpPost("createUser")]
        public async Task<Result> CreateUser([FromBody] UserRegistrationRequestDto data)
        {
            return await _mainDbInteractor
                .CreateUser(data.ConvertToDomainLayer())
                .ConvertToResult("User created");
        }

        [HttpDelete("deleteUser")]
        public async Task<Result> DeleteUserById([FromQuery] long id)
        {
            return await _mainDbInteractor
                .RemoveUserById(id)
                .ConvertToResult($"User {id} removed");
        }

        [HttpPost("getUserId")]
        public async Task<Result<long>> GetIdByUsername([FromQuery] string username)
        {
            return await _mainDbInteractor
                .GetIdByUsername(username)
                .ConvertToResult("Get user id by username");
        }

        [HttpPost("getUser")]
        public async Task<Result<UserProfileResponseDto>> GetUserProfileById([FromQuery] long id)
        {
            return await _mainDbInteractor
                .GetUserProfileById(id)
                .MapResult(u => u.ConvertToPresentationLayer())
                .ConvertToResult("Get user profile by id");
        }

        [HttpPost("createArticle")]
        public async Task<Result> CreateArticle([FromBody] ArticleRegistrationResponseDto article)
        {
            return await _mainDbInteractor
                .CreateArticle(article.ConvertToDomainLayer())
                .ConvertToResult("Article created");
        }

        [HttpPost("removeArticle")]
        public async Task<Result> RemoveArticle([FromQuery] long id)
        {
            return await _mainDbInteractor
                .RemoveArticleById(id)
                .ConvertToResult($"Article {id} deleted");
        }

        [HttpPost("getArticle")]
        public async Task<Result<ArticleViewResponseDto>> GetArticleById([FromQuery] long id)
        {
            return await _mainDbInteractor
                .GetArticleById(id)
                .MapResult(p => p.ConvertToPresentationLayer())
                .ConvertToResult($"Get article {id}");
        }
    }
}