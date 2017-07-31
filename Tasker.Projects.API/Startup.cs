using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tasker.Common.Core.Bus;
using Tasker.Common.Core.Domain;
using Tasker.Common.Core.Events;
using Tasker.Infrastructure.Elasticsearch;
using Tasker.Infrastructure.EventStore;
using Tasker.Projects.Application.Mappers;
using Tasker.Projects.Application.Services;
using Tasker.Projects.Application.Validations;
using Tasker.Projects.Domain.Bus;
using Tasker.Projects.Domain.Factories;
using Tasker.Projects.Domain.Handlers;
using Tasker.Projects.Domain.Mappers;
using Tasker.Projects.Infractructure.ReadModel.Repositories;
using Tasker.Users.API.Client;
using EventStoreImpl = Tasker.Common.Infrastructure.WriteModel.EventStore.EventStore;

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

            //TODO: Move common dependencies to separate file/class
            services.AddTransient<IProjectsCommandService, ProjectsCommandService>();
            services.AddTransient<IProjectCommandMapper, ProjectCommandMapper>();
            services.AddTransient<IProjectCommandBus, InProcessProjectCommandBus>();
            services.AddTransient<IProjectCommandHandler, ProjectCommandHandler>();
            services.AddTransient<ISession, Session>();
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IEventStore, EventStoreImpl>();
            services.AddTransient<IEventPublisher, EventBusPublisher>();
            services.AddTransient<IProjectFactory, ProjectFactory>();
            services.AddTransient<IEventBus, InProcessProjectEventBus>();
            services.AddTransient<IProjectEventHandler, ProjectEventHandler>();
            services.AddTransient<IProjectReadModelMapper, ProjectReadModelMapper>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IElasticClientFactory, ElasticClientFactory>();
            services.AddTransient<IProjectsQueryService, ProjectsQueryService>();
            services.AddTransient<IEventStoreClientFactory, EventStoreClientFactory>();
            services.AddTransient<IProjectCommandValidation, ProjectCommandValidation>();
            services.AddTransient<IUserApiClient, UserApiClient>();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
