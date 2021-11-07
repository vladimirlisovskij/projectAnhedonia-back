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

            // ��������� ����, ����� ������� ����� ���� ������ ������������ � ������� IP � ������.
            // ������, ���� �� ����� ����� (���� ��� �� �����, ��� ����� ����������� �����)
            services.AddCors(options =>
            {
                options.AddPolicy(allowSpecificOrigins,
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });

            // ��� ��� � ���� ��� ����� dependency injection, � ������� � �������.
            // ��� ��� ServiceLifetime.Transient ��������, ��� �� ������ ������ ����� ���� �����������
            // MainDatabaseContext, �.�. ������ ������ ����� ����� � �� ��� ������� ������������
            services.AddDbContext<MainDatabaseContext>(options =>
            {
                options.UseSqlite("Data source=db/MainDatabase.db");
            },
                ServiceLifetime.Transient
            );

            // �� ����� ������� �� ��������� ��� ������������� �������, � ��������� ;)
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

            // �������������� ��, ���� � ������ ��� �� ����, �� ����� � ������ ��
            if (!File.Exists("db/MainDatabase.db"))
            {
                File.Copy("db/MainDatabase_empty.db", "db/MainDatabase.db");
            }
        }
    }
}
