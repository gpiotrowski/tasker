using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tasker.Common.Core.Domain;
using Tasker.Common.Core.Events;
using Tasker.Projects.Application.Mappers;
using Tasker.Projects.Application.Services;
using Tasker.Projects.Domain.Bus;
using Tasker.Projects.Domain.Factories;
using Tasker.Projects.Domain.Handlers;
using Tasker.Projects.Domain.Mappers;
using Tasker.Projects.Infractructure.ReadModel.Repositories;
using Tasker.Projects.Infractructure.WriteModel.EventStore;

namespace Tasker.Projects.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IProjectsCommandService, ProjectsCommandService>();
            services.AddTransient<IProjectCommandMapper, ProjectCommandMapper>();
            services.AddTransient<IProjectCommandBus, InProcessProjectCommandBus>();
            services.AddTransient<IProjectCommandHandler, ProjectCommandHandler>();
            services.AddTransient<ISession, Session>();
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IEventStore, InMemoryEventStore>();
            services.AddTransient<IEventPublisher, EventBusPublisher>();
            services.AddTransient<IProjectFactory, ProjectFactory>();
            services.AddTransient<IProjectEventBus, InProcessProjectEventBus>();
            services.AddTransient<IProjectEventHandler, ProjectEventHandler>();
            services.AddTransient<IProjectReadModelMapper, ProjectReadModelMapper>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
