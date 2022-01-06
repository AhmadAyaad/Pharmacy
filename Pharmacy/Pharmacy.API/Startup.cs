using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using ZPharmacy.API.EventHandler;
using ZPharmacy.API.EventHandler.ISubscribers;
using ZPharmacy.API.EventHandler.Subscribers;
using ZPharmacy.API.Hubs;
using ZPharmacy.API.Services;
using ZPharmacy.Core.Extensions;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Identity.Extensions;
using ZPharmacy.Identity.IServices;
using ZPharmacy.Infrastructure.Data;
using ZPharmacy.Infrastructure.Extensions;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API
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

            services.Configure<JWT>(Configuration.GetSection("JWT"));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<PharmacyDbContext>();
            services.AddInfrastrucuteServices(Configuration.GetConnectionString("pharmacyConnString"));
            services.AddIdentityServices();
            services.AddCoreServices();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSignalR();

            services.AddScoped<IEventSubscriber, EventSubscriber>();
            services.AddScoped<IEventsSubscription, EventsSubscription>();
            services.AddHostedService<ServicesStartup>();
            //services.AddScoped<UploadFileUtil>();
            //services.AddMvc().AddSessionStateTempDataProvider();

            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling =
                       Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(o =>
           {
               o.RequireHttpsMetadata = false;
               o.SaveToken = false;
               o.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero,
                   ValidIssuer = Configuration["JWT:Issuer"],
                   ValidAudience = Configuration["JWT:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
               };
               o.Events = new JwtBearerEvents
               {
                   OnMessageReceived = context =>
                   {
                       var accessToken = context.Request.Query["access_token"];
                       var path = context.HttpContext.Request.Path;
                       if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments($"/{nameof(NotificationHub)}")))
                       {
                           context.Token = accessToken;
                       }
                       return Task.CompletedTask;
                   }
               };
           });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pharamcy API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Ahmad Ayad",
                        Email = "ahmedayad45@gmail.com",
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });
            MigratToLastestDbVersion(app);
            app.UseRouting();

            app.UseCors(options => options.WithOrigins(Configuration.GetSection("ZPharmacyWebOrigin").Value)
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>($"/{nameof(NotificationHub)}");
                endpoints.MapControllers();
            });
        }
        private void MigratToLastestDbVersion(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PharmacyDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}