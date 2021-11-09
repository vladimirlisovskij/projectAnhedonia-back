using System.Threading.Tasks;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.Comment;
using projectAnhedonia_back.Domain.Entities.Dto.User;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Domain.Interactors
{
    public class MainDbInteractor
    {
        private readonly IMainDbRepository _mainDbRepository;
        private readonly IImageRepository _imageRepository;

        public MainDbInteractor(IMainDbRepository mainDbRepository, IImageRepository imageRepository)
        {
            _mainDbRepository = mainDbRepository;
            _imageRepository = imageRepository;
        }

        public string GetImagePathByName(string name)
        {
            return _imageRepository.GetImagePath(name);
        }
        
        public Task<long> GetUserIdByUsername(string username)
        {
            return _mainDbRepository.GetUserIdByUsername(username);
        }

        public Task CreateUser(UserRegistrationDto userRegistration)
        {
            return _mainDbRepository.CreateUser(userRegistration);
        }

        public Task UpdateUser(UserUpdateDto userUpdateDto)
        {
            return _mainDbRepository.UpdateUserProfileById(userUpdateDto);
        }

        public Task ChangeUserPassword(UserChangePasswordDto userChangePasswordDto)
        {
            return _mainDbRepository.ChangeUserPasswordById(userChangePasswordDto);
        }

        public Task RemoveUserById(long id)
        {
            return _mainDbRepository.RemoveUserById(id);
        }

        public Task<UserProfileDto> GetUserProfileById(long id)
        {
            return _mainDbRepository.GetUserProfileById(id);
        }

        public Task CreateArticle(ArticleRegistrationWithRawImageDto article)
        { 
            return _mainDbRepository
                .CreateArticle(article.ConvertToImageName())
                .MapResult(id =>
                {
                    var name = _imageRepository.CreateImage(article.Image);
                    return _mainDbRepository.AddImage(id, name);
                }
            );
        }

        public Task RemoveArticleById(long selfId, long articleId)
        {
            return _mainDbRepository.RemoveArticleById(selfId, articleId)
                .ContinueWith(t => _imageRepository.DeleteImage(t.Result));
        }

        public Task UpdateArticle(ArticleUpdateDto article)
        {
            return _mainDbRepository.UpdateArticle(article);
        }

        public Task<ArticleViewDto> GetArticleById(long id)
        {
            return _mainDbRepository.GetArticleById(id);
        }

        public Task CreateComment(CommentCreateDto data)
        {
            return _mainDbRepository.CreateComment(data);
        }

        public Task<CommentViewDto> GetCommentById(long id)
        {
            return _mainDbRepository.GetCommentById(id);
        }

        public Task RemoveCommentById(long selfId, long commentId)
        {
            return _mainDbRepository.RemoveCommentById(selfId, commentId);
        }

        public Task UpdateCommentById(CommentUpdateDto data)
        {
            return _mainDbRepository.UpdateCommentById(data);
        }

        public Task AddCoauthor(long selfId, long articleId, long coauthorId)
        {
            return _mainDbRepository.AddCoauthor(selfId, articleId, coauthorId);
        }

        public Task RemoveCoauthor(long selfId, long articleId, long coauthorId)
        {
            return _mainDbRepository.RemoveCoauthor(selfId, articleId, coauthorId);
        }
    }
}