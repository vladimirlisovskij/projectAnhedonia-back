using System.Collections.Generic;
using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.User;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Domain.Interactors
{
    public class TestInteractor
    {
        private readonly IMainDbRepository _mainDbRepository;

        public TestInteractor(IMainDbRepository mainDbRepository)
        {
            _mainDbRepository = mainDbRepository;
        }

        public Task<IEnumerable<UserProfileDto>> GetAllUsers()
        {
            return _mainDbRepository.GetAllUsers();
        }

        public Task<IEnumerable<ArticleViewDto>> GetAllArticles()
        {
            return _mainDbRepository.GetAllArticles();
        }
    }
}