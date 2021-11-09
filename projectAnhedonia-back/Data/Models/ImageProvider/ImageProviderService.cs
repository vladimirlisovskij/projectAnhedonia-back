using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using projectAnhedonia_back.Data.Common;

namespace projectAnhedonia_back.Data.Models.ImageProvider
{
    public class ImageProviderService
    {
        public string CreateImage(IFormFile image)
        {
            var name = Tools.sha256_hash(DateTime.Now.ToString()) + GetImageType(image);
            var path = Constants.ImagesPath + name;
            var fileStream = File.Create(path);
            var imageSteam = image.OpenReadStream();
            try
            {
                imageSteam.CopyTo(fileStream);
            }
            finally
            {
                fileStream.Close();
                imageSteam.Close();
            }

            return name;
        }

        public string GetImagePath(string name)
        {
            return Path.GetFullPath(Constants.ImagesPath + name);
        }
        
        public void UpdateImage(IFormFile image, string name)
        {
            GetImageType(image);
            var path = Constants.ImagesPath + name;
            // if (File.Exists(path))
            // {
            //     File.Delete(path);
            // }
            var fileStream = File.Create(path);
            var imageSteam = image.OpenReadStream();
            try
            {
                imageSteam.CopyTo(fileStream);
            }
            finally
            {
                fileStream.Close();
                imageSteam.Close();
            }
        }

        public void DeleteImage(string name)
        {
            var path = Constants.ImagesPath + name;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private string GetImageType(IFormFile file)
        {
            return file.ContentType switch
            {
                "image/jpeg" => ".jpeg",
                "image/png" => ".png",
                _ => throw new Exception("Unknown image format")
            };
        }
    }
}