using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Domain.Interactors;
using projectAnhedonia_back.Presentation.Common;
using projectAnhedonia_back.Presentation.Entities.Dto;
using projectAnhedonia_back.Presentation.Entities.Dto.Article;
using projectAnhedonia_back.Presentation.Entities.Dto.Comment;
using projectAnhedonia_back.Presentation.Entities.Dto.User;
using projectAnhedonia_back.Presentation.Entities.Exceptions;
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

        [HttpPost("getUserId")]
        public async Task<Result<long>> GetUserIdByUsername([FromQuery] string username)
        {
            return await _mainDbInteractor
                .GetUserIdByUsername(username)
                .ConvertToResult($"User id for user {username}");
        }

        [HttpPost("createSelfArticle")]
        public async Task<Result> CreateArticle([FromForm] ArticleRegistrationResponseDto article)
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

        [HttpPost("selfProfile")]
        public async Task<Result<UserProfileResponseDto>> GetSelfId()
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .GetUserProfileById(uid)
                .MapResult(p => p.ConvertToPresentationLayer())
                .ConvertToResult("Self profile");
        }


        [HttpPost("createSelfComment")]
        public async Task<Result> CreateComment([FromBody] CommentCreateResponseDto data)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .CreateComment(data.ConvertToDomainLayer(uid))
                .ConvertToResult("Comment created");
        }

        [HttpPost("updateSelfComment")]
        public async Task<Result> UpdateComment([FromBody] CommentUpdateResponseDto data)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .UpdateCommentById(data.ConvertToDomainLayer(uid))
                .ConvertToResult("User comment updated");
        }

        [HttpPost("getComment")]
        public async Task<Result<CommentViewResponseDto>> GetCommentById([FromQuery] long id)
        {
            return await _mainDbInteractor
                .GetCommentById(id)
                .MapResult(c => c.ConvertToPresentationLayer())
                .ConvertToResult("Get user comment");
        }

        [HttpDelete("removeSelfComment")]
        public async Task<Result> RemoveSelfCommentById([FromQuery] long id)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .RemoveCommentById(uid, id)
                .ConvertToResult("User comment deleted");
        }

        [HttpPost("addSelfCoauthor")]
        public async Task<Result> AddCoauthorById([FromQuery] long articleId, [FromQuery] long coauthorId)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .AddCoauthor(uid, articleId, coauthorId)
                .ConvertToResult($"Added coauthor {coauthorId} to article {articleId}");
        }

        [HttpDelete("deleteSelfCoauthor")]
        public async Task<Result> RemoveCoauthorById([FromQuery] long articleId, [FromQuery] long coauthorId)
        {
            var uid = ExtractUserIdFromBearer();
            return await _mainDbInteractor
                .RemoveCoauthor(uid, articleId, coauthorId)
                .ConvertToResult($"Removed coauthor {coauthorId} from article {articleId}");
        }

        [HttpGet("image/{name}")]
        public IActionResult GetImage(string name)
        {
            var path = _mainDbInteractor.GetImagePathByName(name);
            var type = "image/" + path.Split(".").Last();
            
            return PhysicalFile(path, type);
        }

        private long ExtractUserIdFromBearer()
        {
            try
            {
                var token = Request.Headers["Authorization"].First().Split(" ").Last();
                return _authorizationInteractor.GetUserIdFromBearer(token);
            }
            catch (InvalidOperationException)
            {
                throw new RequireAuthorizationException("this request requires authorization. Check your token");
            }
        }
    }
}