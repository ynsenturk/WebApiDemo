﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmreSenturk.WebApiDemo.CustomMiddlewares;
using EmreSenturk.WebApiDemo.DataAccess;
using EmreSenturk.WebApiDemo.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmreSenturk.WebApiDemo
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
            services.AddScoped<IProductDal,EfProductDal>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new VcardOutputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();

            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMvc(config =>
            {
                //config.MapRoute("DefaultRoute", "api/{controller}/{action}");
            });
        }
    }
}
