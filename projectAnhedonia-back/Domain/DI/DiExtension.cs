using Microsoft.Extensions.DependencyInjection;
using projectAnhedonia_back.Domain.Usecase;

namespace projectAnhedonia_back.Domain.DI
{
    public static class DiExtension
    {
        public static void AddDomainBindings(this IServiceCollection services)
        {
            services.BindUsecase();
        }


        static void BindUsecase(this IServiceCollection services)
        {
            services.AddScoped<GetAllTestItemsCase>();
            services.AddScoped<InsertTestItemsCase>();
        }
    }
}