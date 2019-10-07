﻿using System;
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
using WeedShop.Core.ApplicationService.Implementation;
using WeedShop.Core.DomainService;
using WeedShop.InfraStructure.SQL;
using WeedShop.InfraStructure.SQL.Repositories;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
