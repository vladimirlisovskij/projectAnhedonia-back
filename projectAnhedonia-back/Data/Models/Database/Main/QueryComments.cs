using System.Threading.Tasks;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public  partial class MainDatabaseContext 
    {
        public Task<int> CreateComment(Comment comment)
        {
            Comments.Add(comment);
            return SaveChangesAsync();
        }

        // public Task<Comment> GetCommentById(long id)
        // {
        //     return Comments
        //         .Where(c => c.Id == id)
        //         .Select(u => new UserProfile
        //         {
        //             Username = u.Username,
        //             About = u.About,
        //             RegistrationDate = u.RegistrationDate,
        //             Articles = u.Posts.Select(a => a.Id)
        //         })
        //         .FirstAsync();
        // }
    }
}