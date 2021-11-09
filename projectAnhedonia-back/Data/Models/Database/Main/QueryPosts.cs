using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext
    {
        public Task<long> AddArticle(Post article)
        {
            Posts.Add(article);
            return SaveChangesAsync().MapResult(_ => article.Id);
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
                    Comments = p.Comments.Select( p => p.Id),
                    Coauthors = p.Coauthors.Select(c => c.UserId),
                    ImageName = p.PreviewImage.FilePath
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
                    Comments = p.Comments.Select(c => c.Id),
                    Coauthors = p.Coauthors.Select(c => c.UserId),
                    ImageName = p.PreviewImage.FilePath
                })
                .FirstAsync();
        }

        public Task<string> RemoveArticleById(long selfId, long articleId)
        {
            var post = Posts.Include(p => p.PreviewImage).First(p => p.Id == articleId && p.AuthorId == selfId);
            string res = (string) post.PreviewImage.FilePath.Clone();
            Posts.Remove(post);
            return SaveChangesAsync().MapResult( _ => res);
        }

        public Task<int> UpdateArticle(Post article)
        {
            var oldArticle = Posts.First(
                a => a.Id == article.Id 
                     && (a.AuthorId == article.AuthorId 
                         || a.Coauthors.Select(c => c.UserId).Contains((long)article.AuthorId)
                         )
                     );

            oldArticle.Title = article.Title;
            oldArticle.Content = article.Content;

            return SaveChangesAsync();
        }
    }
}