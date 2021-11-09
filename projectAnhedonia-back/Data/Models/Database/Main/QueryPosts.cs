using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext
    {
        public Task<int> AddArticle(Post article)
        {
            Posts.Add(article);
            return SaveChangesAsync();
        }

        public Task<List<PostView>> GetAllPosts()
        {
            return Posts
                .Select(p => new PostView
                {
                    Title = p.Title,
                    AuthorId = p.AuthorId,
                    Content = p.Content,
                    CreationDateTime = p.CreationDateTime,
                    Comments = p.Comments.Select( p => p.Id)
                })
                .ToListAsync();
        }

        public Task<PostView> GetArticleById(long id)
        {
            return Posts
                .Where(p => p.Id == id)
                .Select(p => new PostView
                {
                    Title = p.Title,
                    AuthorId = p.AuthorId,
                    Content = p.Content,
                    CreationDateTime = p.CreationDateTime,
                    Comments = p.Comments.Select(c => c.Id)
                })
                .FirstAsync();
        }

        public Task<int> RemoveArticleById(long selfId, long articleId)
        {
            Posts.Remove(new Post {AuthorId = selfId, Id = articleId});
            return SaveChangesAsync();
        }

        public Task<int> UpdateArticle(Post article)
        {
            var oldArticle = Posts.First(a => a.Id == article.Id && a.AuthorId == article.AuthorId);

            oldArticle.Title = article.Title;
            oldArticle.Content = article.Content;

            return SaveChangesAsync();
        }
    }
}