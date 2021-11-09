using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace projectAnhedonia_back.Domain.Repositories
{
    public interface IImageRepository
    {
        public string GetImagePath(string name);
        public string CreateImage(IFormFile image);
        public void UpdateImage(IFormFile image, string name);
        public void DeleteImage(string name);
    }
}