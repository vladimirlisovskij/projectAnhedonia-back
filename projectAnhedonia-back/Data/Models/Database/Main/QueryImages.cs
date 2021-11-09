using System.Linq;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public  partial class MainDatabaseContext 
    {
        public int AddImage(long articleId, string imageName)
        {
            Posts.First(p => p.Id == articleId).PreviewImage = new Image {FilePath = imageName, Title = imageName};
            return SaveChanges();
        }
    }
}