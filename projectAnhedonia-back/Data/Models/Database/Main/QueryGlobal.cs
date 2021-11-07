using System.Threading.Tasks;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public  partial class MainDatabaseContext 
    {
        public Task<int> ClearDatabase()
        {
            Users.RemoveRange(Users);
            Posts.RemoveRange(Posts);
            Images.RemoveRange(Images);
            Coauthors.RemoveRange(Coauthors);
            Comments.RemoveRange(Comments);

            return SaveChangesAsync();
        }
    }
}