using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projectAnhedonia_back.Data.Models.Authorization;
using projectAnhedonia_back.Data.Models.Database.Main;
using projectAnhedonia_back.Data.Models.ImageProvider;
using projectAnhedonia_back.Data.Repositories;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Data.Common
{
    public static class DiExt
    {
        public static void AddDataLayerBindings(this IServiceCollection services)
        {
            services.BindRepository();
            services.BindModel();
        }
        
        static void BindModel(this IServiceCollection services)
        {
            services.AddDbContext<MainDatabaseContext>(options =>
                {
                    options.UseSqlite($"Data source={Constants.MainDatabasePath}");
                },
                ServiceLifetime.Transient
            );
            
            services.AddScoped<AuthorizationService>();
            services.AddScoped<ImageProviderService>();
        }
        
        static void BindRepository(this IServiceCollection services)
        {
            services.AddScoped<IMainDbRepository, MainDbRepositoryImpl>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepositoryImpl>();
            services.AddScoped<IImageRepository, ImageRepositoryImpl>();
        }
    }
}