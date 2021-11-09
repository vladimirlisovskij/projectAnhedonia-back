using System.Collections.Generic;
using System.Threading.Tasks;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Domain.Entities.Dto;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.Comment;
using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Domain.Repositories
{
    public interface IMainDbRepository
    {
        public Task CreateUser(UserRegistrationDto userRegistration);

        public Task RemoveUserById(long id);

        public Task<long> GetUserIdByUsername(string username);

        public Task<UserProfileDto> GetUserProfileById(long id);

        public Task UpdateUserProfileById(UserUpdateDto profileInfo);

        public Task ChangeUserPasswordById(UserChangePasswordDto userChangePasswordDto);

        public Task<long> GetIdByCreds(UserCredsDto creds);

        public Task<long> CreateArticle(ArticleRegistrationWithImageNameDto data);

        public Task<ArticleViewDto> GetArticleById(long id);
        
        public Task<string> RemoveArticleById(long selfId, long articleId);

        public Task UpdateArticle(ArticleUpdateDto data);

        public Task CreateComment(CommentCreateDto data);

        public Task<CommentViewDto> GetCommentById(long id);

        public Task RemoveCommentById(long selfId, long commentId);

        public Task UpdateCommentById(CommentUpdateDto data);

        public Task AddCoauthor(long selfId, long articleId, long coauthorId);
        public Task RemoveCoauthor(long selfId, long articleId, long coauthorId);

        public int AddImage(long articleId, string name);

        // ======= only for test =======
        public Task<IEnumerable<UserProfileDto>> GetAllUsers();

        public Task<IEnumerable<ArticleViewDto>> GetAllArticles();
    }
}