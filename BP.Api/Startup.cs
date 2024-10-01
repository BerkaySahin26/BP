using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BP.Api.Extensions;
using BP.Api.Models;
using BP.Api.Service;
using BP.Api.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using BP.Api.BackgroundServices;
using BP.Api.Logging;

namespace BP.Api
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
            services.AddControllers()
                .AddFluentValidation(i => i.RunDefaultMvcValidationAfterFluentValidationExecutes = false);


            
            services.AddHealthChecks();
            services.ConfigureMapping();
            services.AddScoped<IContactService, ContactService>();
            services.AddTransient<IValidator<ContactDVO>, ContactValidator>();
            services.AddHttpClient("garantiapi", Config =>
            {
                Config.BaseAddress = new Uri("http://www.garanti.com");
                Config.DefaultRequestHeaders.Add("Authorization", "Bearer 1212121");
            });


            services.AddHostedService<DataTimeLogWriter>();
            services.AddLogging();

            //services.AddLogging(i =>
            //{
            //    i.ClearProviders();
            //    i.SetMinimumLevel(LogLevel.Information);
            //    //i.AddDebug();
            //    i.AddProvider(new MyCustomLoggerFactory());

            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCustomHealthCheck();
            app.UseResponseCaching();

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
