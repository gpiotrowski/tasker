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
using Tasker.Users.Application.Mappers;
using Tasker.Users.Application.Services;
using Tasker.Users.Domain.Bus;
using Tasker.Users.Domain.Factories;
using Tasker.Users.Domain.Handlers;
using Tasker.Users.Domain.Mappers;
using Tasker.Users.Infrastructure.ReadModel.Repositories;
using EventStoreImpl = Tasker.Common.Infrastructure.WriteModel.EventStore.EventStore;

namespace Tasker.Users.API
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
            services.AddTransient<IUserCommandService, UserCommandService>();
            services.AddTransient<IUserCommandMapper, UserCommandMapper>();
            services.AddTransient<IUserCommandBus, InProcessUserCommandBus>();
            services.AddTransient<IUserCommandHandler, UserCommandHandler>();
            services.AddTransient<ISession, Session>();
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IEventStore, EventStoreImpl>();
            services.AddTransient<IEventPublisher, EventBusPublisher>();
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<IEventBus, InProcessUserEventBus>();
            services.AddTransient<IUserEventHandler, UserEventHandler>();
            services.AddTransient<IUserReadModelMapper, UserReadModelMapper>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IElasticClientFactory, ElasticClientFactory>();
            services.AddTransient<IEventStoreClientFactory, EventStoreClientFactory>();
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
                    template: "api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
