using System.IO;
using Microsoft.AspNetCore.Builder;

namespace projectAnhedonia_back.Data.Common
{
    public static class ConfigurationExt
    {
        public static IApplicationBuilder ConfigureDataLayer(this IApplicationBuilder app)
        {
            if (!File.Exists(Constants.MainDatabasePath))
            {
                File.Copy(Constants.EmptyMainDatabasePath, Constants.MainDatabasePath);
            }
            
            return app;
        }
    }
}