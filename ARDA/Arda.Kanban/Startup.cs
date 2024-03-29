﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Arda.Kanban.Models;
using Arda.Common.Interfaces.Kanban;
using Arda.Kanban.Repositories;
using Arda.Common.Middlewares;

namespace Arda.Kanban
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("secrets.json");

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();//.ReloadOnChanged("appsettings.json");
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCors(x => x.AddPolicy("AllowAll", c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            // Registering distributed cache approach to the application.
            services.AddSingleton<IDistributedCache>(serviceProvider => new RedisCache(new RedisCacheOptions
            {
                Configuration = Configuration["Storage:Redis:Configuration"],
                InstanceName = Configuration["Storage:Redis:InstanceName"]
            }));

            //// Adding database connection by dependency injection.
            var connectionString = Configuration["Storage:SqlServer:ConnectionString"];
            services.AddEntityFramework().AddSqlServer().AddDbContext<KanbanContext>(options => options.UseSqlServer(connectionString));

            //Registering services.
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFiscalYearRepository, FiscalYearRepository>();
            services.AddScoped<IMetricRepository, MetricRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IWorkloadRepository, WorkloadRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseMiddleware<SecurityAPIMiddleware>();

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
