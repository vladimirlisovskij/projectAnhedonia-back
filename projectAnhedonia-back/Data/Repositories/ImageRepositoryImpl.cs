using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using projectAnhedonia_back.Data.Models.ImageProvider;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Data.Repositories
{
    public class ImageRepositoryImpl: IImageRepository
    {
        private readonly ImageProviderService _service;

        public ImageRepositoryImpl(ImageProviderService service)
        {
            _service = service;
        }
        
        public string CreateImage(IFormFile image)
        {
            return _service.CreateImage(image);
        }

        public void UpdateImage(IFormFile image, string name)
        {
            _service.UpdateImage(image, name);
        }

        public void DeleteImage(string name)
        {
            _service.DeleteImage(name);
        }

        public string GetImagePath(string name)
        {
            return _service.GetImagePath(name);
        }
    }
}