using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.User;
using projectAnhedonia_back.Domain.Repositories;

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

        public Task RemoveUserById(long id)
        {
            return _mainDbRepository.RemoveUserById(id);
        }

        // TODO change username to token or something else that we get after registration complete
        public Task<long> GetIdByUsername(string username)
        {
            return _mainDbRepository.GetIdByUsername(username);
        }

        public Task<UserProfileDto> GetUserProfileById(long id)
        {
            return _mainDbRepository.GetUserProfileById(id);
        }

        public Task CreateArticle(ArticleRegistrationDto article)
        {
            return _mainDbRepository.CreateArticle(article);
        }

        public Task RemoveArticleById(long id)
        {
            return _mainDbRepository.RemoveArticleById(id);
        }

        public Task<ArticleViewDto> GetArticleById(long id)
        {
            return _mainDbRepository.GetArticleById(id);
        }
    }
}