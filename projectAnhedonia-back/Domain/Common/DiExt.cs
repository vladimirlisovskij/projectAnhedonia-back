using Microsoft.Extensions.DependencyInjection;
using projectAnhedonia_back.Domain.Interactors;

namespace projectAnhedonia_back.Domain.Common
{
    public static class DiExt
    {
        public static void AddDomainLayerBindings(this IServiceCollection services)
        {
            services.BindInteractors();
        }

        static void BindInteractors(this IServiceCollection services)
        {
            services.AddScoped<MainDbInteractor>();
            services.AddScoped<TestInteractor>();
        }
    }
}