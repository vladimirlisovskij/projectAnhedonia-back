using System.Collections.Generic;
using System.Threading.Tasks;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Domain.Entities.Dto;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Domain.Repositories
{
    public interface IMainDbRepository
    {
        public Task CreateUser(UserRegistrationDto userRegistration);

        public Task RemoveUserById(long id);
        
        public Task<UserProfileDto> GetUserProfileById(long id);

        public Task UpdateUserProfileById(UserUpdateDto profileInfo);

        public Task ChangeUserPasswordById(UserChangePasswordDto userChangePasswordDto);

        public Task<long> GetIdByCreds(UserCredsDto creds);

        public Task CreateArticle(ArticleRegistrationDto data);

        public Task<ArticleViewDto> GetArticleById(long id);
        
        public Task RemoveArticleById(long selfId, long articleId);

        public Task UpdateArticle(ArticleUpdateDto data);

        // ======= only for test =======
        public Task<IEnumerable<UserProfileDto>> GetAllUsers();

        public Task<IEnumerable<ArticleViewDto>> GetAllArticles();
    }
}