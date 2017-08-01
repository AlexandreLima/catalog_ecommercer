using EcommercerCatalog.Application.Entity.Contracts;
using EcommercerCatalog.Application.Entity.Implementation;
using EcommercerCatalog.Application.Tasks.Contracts.Sku;
using EcommercerCatalog.Application.Tasks.Implements.Sku;
using EcommercerCatalog.Infraestruture.Data.Repository.Contracts.Sku;
using EcommercerCatalog.Infraestruture.Data.Repository.Impl.Mongo.Sku;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EcommercerCatalog
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

            services.AddTransient<IImportSkuTaskService, ImportSkuTaskService>();
            services.AddTransient<ISkuEntityService, SkuEntityService>();
            services.AddTransient<ISkuRepository, SkuRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}