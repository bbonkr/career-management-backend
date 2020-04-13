using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerManagement.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CareerManagement.Web.Stores;
using CareerManagement.Web.Seed;

namespace CareerManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Default"), sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly($"{typeof(DataContext).Namespace}.SqlServer");
                });
            });

            services.AddTransient<CareerStore>();
            services.AddTransient<MyData>();

            services.AddHealthChecks();

            services.AddCors(options => {
                var defaultPolicy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();

                defaultPolicy.Origins.Add("localhost");

                options.AddPolicy("Default", defaultPolicy);
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var scope=app.ApplicationServices.CreateScope();
                using (var db = scope.ServiceProvider.GetService<DataContext>())
                {
                    db.Database.Migrate();

                    Console.WriteLine(">>> 데이터베이스 마이그레이션 완료");

                    var myData=scope.ServiceProvider.GetService<MyData>();
                    //if (myData.IsExists())
                    //{
                    //    myData.Clear();
                    //    Console.WriteLine(">>> 데이터 초기화 완료");
                    //}

                    if (!myData.IsExists())
                    {
                        myData.Seed();

                        Console.WriteLine(">>> 데이터 입력 완료");
                    }
                }
            }
            app.UseCors();

            app.UseHttpsRedirection();
            app.UseHealthChecks(new Microsoft.AspNetCore.Http.PathString("/health"));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
