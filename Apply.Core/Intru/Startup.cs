using Intru.Library;
using Intru.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intru
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConection = "server=156.67.72.1; port=3306; database=u922704232_apply; user=u922704232_wesley; password={Programador}2";//Configuration.GetConnectionString("Conn");
            string[] origins = new string[] { "https://intru.net", "http://intru" };

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //                      {
            //                          builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
            //                      });
            //});

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Intru", Version = "v1" });
            });

            services.AddSingleton<Context, Context>();

            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ICardsService, CardsService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ICategoryService, CategoryService>(); 

            services.AddDbContextPool<Context>(options =>
                options.UseMySql(mySqlConection,
                      ServerVersion.AutoDetect(mySqlConection), b => b.MigrationsAssembly("Intru.Library")));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{                
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Intru v1"));
            //}

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Intru v1"));

            //app.UseCors();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
