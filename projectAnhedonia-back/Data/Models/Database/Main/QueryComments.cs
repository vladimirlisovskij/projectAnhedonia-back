using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext
    {
        public Task<int> CreateComment(Comment comment)
        {
            Comments.Add(comment);
            return SaveChangesAsync();
        }

        public Task<Comment> GetCommentById(long id)
        {
            return Comments
                .FirstAsync(c => c.Id == id);
        }

        public Task<int> DeleteCommentById(long selfId, long id)
        {
            var comment = new Comment {AuthorId = selfId, Id = id};
            Comments.Remove(comment);
            return SaveChangesAsync();
        }

        public Task<int> UpdateComment(Comment comment)
        {
            var oldComment = Comments.First(c => c.AuthorId == comment.AuthorId && c.Id == comment.Id);

            oldComment.Content = comment.Content;

            return SaveChangesAsync();
        }
    }
}