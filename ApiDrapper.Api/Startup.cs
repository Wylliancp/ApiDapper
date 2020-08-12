using ApiDrapper.Domain.StoreContext.Repositories;
using ApiDrapper.Domain.StoreContext.Services;
using ApiDrapper.Infra.DataContext;
using ApiDrapper.Infra.Repositories;
using ApiDrapper.Infra.Services;
using ApiDrapper.Shared;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace ApiDrapper.Api
{
    public class Startup
    {

        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            //APPSETTINGS
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            //Fim

            services.AddMvc();
            
            services.AddResponseCompression();

            services.AddScoped<ApiDapperContext, ApiDapperContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "ApiDrapper", Version = "v1" });
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "4e89bd11c63d49ed822e37244e6e8fa9";
                o.LogId = new Guid("2eaaa070-351e-4d8b-b957-c292824aa821");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseElmahIo();

            app.UseMvc();
            
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiDrapper");
            });
        }
    }
}
