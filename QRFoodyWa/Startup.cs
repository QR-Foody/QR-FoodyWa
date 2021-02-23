using DataAccess.StorageTableRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccess.DataStorage;
using System;
using Business;
using Microsoft.Extensions.Logging;
using Business.Interface;
using Business.Interfaces;

namespace QRFoodyWa
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .AddJsonFile("appsettings.Development.json")
                 .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var entityDataStoreOptions = GetEntityDataStoreOptions();

            services.AddSingleton(entityDataStoreOptions);

            RegisterDependencies(services);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }


        private void RegisterDependencies(IServiceCollection services)
        {
            //DataAccess Layer
            services.AddTransient<ISubscriptionEntityDataStorage, SubscriptionEntityDataStorage>();
            services.AddTransient<IMenuEntityDataStorage, MenuEntityDataStorage>();
            services.AddTransient<IProductEntityDataStorage, ProductEntityDataStorage>();
            services.AddTransient<ISubmenuEntityDataStorage, SubmenuEntityDataStorage>();
            services.AddTransient<IUserEntityDataStorage, UserEntityDataStorage>();

            //BusinessLayer
            services.AddTransient<ISubscriptionBo, SubscriptionBo>();
            services.AddTransient<IMenuBo, MenuBo>();
            services.AddTransient<IProductBo, ProductBo>();
            services.AddTransient<ISubmenuBo, SubmenuBo>();
            services.AddTransient<IUserBo, UserBo>();
        }

        private EntityDataStoreOptions GetEntityDataStoreOptions()
        {
            var entityDataStoreOptions =
                new EntityDataStoreOptions();

            var primaryCloudStorageAccount =
                CloudStorageAccount.Parse(
                    Configuration["AzureTableStorageOptions:PrimaryConnectionString"]);

            entityDataStoreOptions.PrimaryCloudTableClient =
                primaryCloudStorageAccount.CreateCloudTableClient();

            if (!string.IsNullOrWhiteSpace(
                Configuration["AzureTableStorageOptions:SecondaryConnectionString"]))
            {
                var secondaryCloudStorageAccount =
                    CloudStorageAccount.Parse(
                        Configuration["AzureTableStorageOptions:SecondaryConnectionString"]);

                entityDataStoreOptions.SecondaryCloudTableClient =
                    secondaryCloudStorageAccount.CreateCloudTableClient();
            }

            return entityDataStoreOptions;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
