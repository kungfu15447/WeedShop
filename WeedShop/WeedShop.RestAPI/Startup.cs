using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeedShop.Core.ApplicationService;
using WeedShop.Core.ApplicationService.Implementation;
using WeedShop.Core.DomainService;
using WeedShop.Core.ExceptionHandling;
using WeedShop.InfraStructure.SQL;
using WeedShop.InfraStructure.SQL.Repositories;
using WeedShop.RestAPI.Initializer;

namespace WeedShop.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWeedRepository, WeedRepository>();
            services.AddScoped<IWeedService, WeedService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IErrorFactory, ErrorFactory>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 3;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                        //.WithOrigins("http://localhost:64934").AllowAnyHeader().AllowAnyMethod()
                        //.WithOrigins("http://db-weedshop-jwh-dk-easv.azurewebsites.net").AllowAnyHeader().AllowAnyMethod()
                        //.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod());

            });

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<WeedShopContext>(
                optionsAction: opt => opt.UseSqlite(
                connectionString: "Data Source = WeedShop.db"));
            }
            else
            {
                services.AddDbContext<WeedShopContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors("AllowSpecificOrigin");

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider
                        .GetRequiredService<WeedShopContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DBInitializer.Seed(context);
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider
                        .GetRequiredService<WeedShopContext>();
                    context.Database.EnsureCreated();
                    DBInitializer.Seed(context);
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
