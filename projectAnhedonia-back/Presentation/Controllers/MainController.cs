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
    public class MainController : ControllerBase
    {
        private readonly MainDbInteractor _mainDbInteractor;
        private readonly AuthorizationInteractor _authorizationInteractor;

        public MainController(MainDbInteractor mainDbInteractor, AuthorizationInteractor authorizationInteractor)
        {
            _mainDbInteractor = mainDbInteractor;
            _authorizationInteractor = authorizationInteractor;
        }

        [HttpPost("createUser")]
        public async Task<Result> CreateUser([FromBody] UserRegistrationRequestDto data)
        {
            return await _mainDbInteractor
                .CreateUser(data.ConvertToDomainLayer())
                .ConvertToResult("User created");
        }

        [HttpPost("selfUpdate")]
        public async Task<Result> UpdateUser([FromBody] UserUpdateRequestDto data)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .UpdateUser(data.ConvertToDomainLayer(uid))
                .ConvertToResult("User updated");
        }

        [HttpPost("selfChangePassword")]
        public async Task<Result> ChangePassword([FromBody] UserChangePasswordRequestDto data)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .ChangeUserPassword(data.ConvertToDomainLayer(uid))
                .ConvertToResult("Changed user password");
        }

        [HttpDelete("selfDelete")]
        public async Task<Result> SelfDelete()
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .RemoveUserById(uid)
                .ConvertToResult($"User {uid} removed");
        }

        [HttpPost("getUser")]
        public async Task<Result<UserProfileResponseDto>> GetUserProfileById([FromQuery] long id)
        {
            return await _mainDbInteractor
                .GetUserProfileById(id)
                .MapResult(u => u.ConvertToPresentationLayer())
                .ConvertToResult("Get user profile by id");
        }

        [HttpPost("createSelfArticle")]
        public async Task<Result> CreateArticle([FromBody] ArticleRegistrationResponseDto article)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .CreateArticle(article.ConvertToDomainLayer(uid))
                .ConvertToResult("Article created");
        }

        [HttpPost("updateSelfArticle")]
        public async Task<Result> UpdateArticle([FromBody] ArticleUpdateResponseDto article)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .UpdateArticle(article.ConvertToDomainLayer(uid))
                .ConvertToResult("Article created");
        }

        [HttpDelete("removeSelfArticle")]
        public async Task<Result> RemoveSelfArticle([FromQuery] long articleId)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .RemoveArticleById(uid, articleId)
                .ConvertToResult($"Article {articleId} deleted");
        }

        [HttpPost("getArticle")]
        public async Task<Result<ArticleViewResponseDto>> GetArticleById([FromQuery] long id)
        {
            return await _mainDbInteractor
                .GetArticleById(id)
                .MapResult(p => p.ConvertToPresentationLayer())
                .ConvertToResult($"Get article {id}");
        }

        [HttpPost("auth")]
        public Task<Result<string>> Authorize([FromBody] UserLoginResponse user)
        {
            return _authorizationInteractor
                .AuthorizeUserByCreds(user.ConvertToPresentationLayer())
                .ConvertToResult("User bearer");
        }

        [HttpPost("selfId")]
        public Result<long> GetSelfId()
        {
            return new Result<long>( "ok",  "Get self id", ExtractUserIdFromBearer());
        }
        
        private long ExtractUserIdFromBearer()
        {
            var token = Request.Headers["Authorization"].First().Split(" ").Last();
            return _authorizationInteractor.GetUserIdFromBearer(token);
        }
    }
}