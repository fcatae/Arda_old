﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Arda.Authentication.Models;
using Microsoft.Data.Entity;
using Arda.Athentication.Repository.Emails;
using Arda.Authentication.Repositories.Authentication;
using Arda.Authentication.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;

namespace Arda.Authentication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build().ReloadOnChanged("appsettings.json");
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Adding MVC module to application.
            services.AddMvc();

            // Adding CORS to the application.
            services.AddCors(x => x.AddPolicy("AllowAll", c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            // Adding database connection by dependency injection.
            //var Connection = @"Server=DESKTOP-JTBG8BF\SQLFABRICIO;Database=Arda_Authentication;User Id=sa;Password=3wuutxsx@;Trusted_Connection=True;";
            var Connection = @"Server=CYZANON1-MS1;Database=Arda_Authentication;User Id=sa;Password=3wuutxsx@;Trusted_Connection=True;";
            services.AddEntityFramework().AddSqlServer().AddDbContext<AuthenticationContext>(options => options.UseSqlServer(Connection));

            // Registering distributed cache approach to the application.
            services.AddSingleton<IDistributedCache>(serviceProvider => new RedisCache(new RedisCacheOptions
                    {
                        Configuration = "arda.redis.cache.windows.net:6380,password=66Tw+4fc8tkeHWr1Els4jtGF1pIhCSP0ncIXB4PuyDk=,ssl=True,abortConnect=False",
                        InstanceName = "arda.redis.cache.windows.net"
            }));

            // Registering another dependencies.
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IAuthentication, Repositories.Authentication.AthenticationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseCors("AllowAll");

            app.UseMvc();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
