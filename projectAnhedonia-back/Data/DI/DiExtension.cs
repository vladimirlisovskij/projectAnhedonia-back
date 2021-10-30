using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projectAnhedonia_back.Data.Models;
using projectAnhedonia_back.Data.Repository;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Data.DI
{
    public static class DiExtension
    {
        public static void AddDataBindings(this IServiceCollection services)
        {
            services.BindRepository();
            services.BindModel();
        }


        static void BindModel(this IServiceCollection services)
        {
            services.AddDbContext<TestDataBaseContext>(opt => opt.UseInMemoryDatabase("TestList"));
        }
        
        static void BindRepository(this IServiceCollection services)
        {
            services.AddScoped<IDataBaseRepository, DataBaseRepository>();
        }
    }
}