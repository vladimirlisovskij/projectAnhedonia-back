using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.User;
using projectAnhedonia_back.Domain.Repositories;
using projectAnhedonia_back.Presentation.Entities.Dto.Article;

namespace projectAnhedonia_back.Domain.Interactors
{
    public class MainDbInteractor
    {
        private readonly IMainDbRepository _mainDbRepository;

        public MainDbInteractor(IMainDbRepository mainDbRepository)
        {
            _mainDbRepository = mainDbRepository;
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

        public Task CreateArticle(ArticleRegistrationDto article)
        {
            return _mainDbRepository.CreateArticle(article);
        }

        public Task RemoveArticleById(long selfId, long articleId)
        {
            return _mainDbRepository.RemoveArticleById(selfId, articleId);
        }

        public Task UpdateArticle(ArticleUpdateDto article)
        {
            return _mainDbRepository.UpdateArticle(article);
        }

        public Task<ArticleViewDto> GetArticleById(long id)
        {
            return _mainDbRepository.GetArticleById(id);
        }
    }
}