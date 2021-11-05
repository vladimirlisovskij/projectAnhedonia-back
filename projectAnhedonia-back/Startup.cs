using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using projectAnhedonia_back.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace projectAnhedonia_back
{
    public class Startup
    {
        private readonly string allowSpecificOrigins = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Добавляем корс, чтобы запросы можно было делать потенциально с другого IP и домена.
            // Уберем, если не будет нужно (пока ещё не знаем, как будет раздаваться фронт)
            services.AddCors(options =>
            {
                options.AddPolicy(allowSpecificOrigins,
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });

            // Вот это и есть тот самый dependency injection, о котором я говорил.
            // При это ServiceLifetime.Transient означает, что на каждый запрос будет свой создаваться
            // MainDatabaseContext, т.е. каждый запрос может лезть в бд без проблем одновременно
            services.AddDbContext<MainDatabaseContext>(options =>
            {
                options.UseSqlite("Data source=db/MainDatabase.db");
            },
                ServiceLifetime.Transient
            );

            // Ты решил сваггер не добавлять при инициализации проекта, я возвращаю ;)
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Инициализируем БД, если её вообще ещё не было, из файла с пустой бд
            if (!File.Exists("db/MainDatabase.db"))
            {
                File.Copy("db/MainDatabase_empty.db", "db/MainDatabase.db");
            }
        }
    }
}
