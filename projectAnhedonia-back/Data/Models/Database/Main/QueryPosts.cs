using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entities.Dto;

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
                    CreationDateTime = p.CreationDateTime
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
                    CreationDateTime = p.CreationDateTime
                })
                .FirstAsync();
        }

        public Task<int> RemoveArticleById(long id)
        {
            Posts.Remove(new Post {Id = id});
            return SaveChangesAsync();
        }
    }
}