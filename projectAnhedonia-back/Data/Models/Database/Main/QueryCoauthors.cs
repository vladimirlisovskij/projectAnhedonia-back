using System.Linq;
using System.Threading.Tasks;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public  partial class MainDatabaseContext 
    {
        public Task<int> RemoveCoauthorById(long selfId, long articleId, long coauthorId)
        {
            Posts.Single(p => p.AuthorId == selfId && p.Id == articleId);
            Coauthors.Remove(new Coauthor {PostId = articleId, UserId = coauthorId});
            return SaveChangesAsync();
        } 

        public Task<int> AddCoauthorById(long selfId, long articleId, long coauthorId)
        {
            Posts.Single(p => p.AuthorId == selfId && p.Id == articleId);
            Coauthors.Add(new Coauthor { PostId = articleId, UserId = coauthorId});
            return SaveChangesAsync();
        }
    }
}