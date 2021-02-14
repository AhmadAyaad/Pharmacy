using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pharmacy.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;
using System;
using Pharmacy.API.Util;
using Pharmacy.Core.Dtos;
using Pharmacy.Domain.Entities;
using Pharmacy.Core.Mapper;

namespace Pharmacy.API
{
    public class Startup
    {
        private readonly IHostEnvironment _environment;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Ioc.ConfigureServices(services, Configuration.GetConnectionString("pharmacyConnString"));
            Pharmacy.Core.Configuration.Ioc.ConfigureServices(services);
            
            services.AddScoped<UploadFileUtil>();
            services.AddScoped<MedicineMapper>();

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10000);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache();

            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling =
                       Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Zomato API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Ankush Jain",
                        Email = string.Empty,
                        Url = new Uri("http://localhost:53147"),
                    },
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zomato API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseSession();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
