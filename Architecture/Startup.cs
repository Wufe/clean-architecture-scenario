using System;
using System.Globalization;
using Architecture.Application.Services;
using Architecture.Application.Services.Implementation;
using Architecture.Cache;
using Architecture.Database;
using Architecture.Database.Entities;
using Architecture.Mappers.Common;
using Architecture.Repositories;
using Architecture.Repositories.EntityFramework;
using Architecture.Repositories.EntityFramework.Shared;
using Architecture.Services;
using Architecture.Services.Implementation;
using Architecture.Services.Implementation.LocalizationService;
using Architecture.Services.Implementation.Serialization;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Architecture.Mvc
{
    public class Startup
    {
        private readonly CultureInfo[] _supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("it")
        };

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            //var useSqliteEnvironment = Environment.GetEnvironmentVariable("USE_SQLITE");
            //bool useSqlite = useSqliteEnvironment != null && useSqliteEnvironment.ToLower().Equals("true");

            services.AddAutoMapper(MappingConfiguration.Configure);

            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "Arc:";
                options.Configuration = Configuration.GetConnectionString("redis");
            });

            services.AddMvc();

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityContext, int>()
                .AddDefaultTokenProviders();

            // Autofac container
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<IdentityContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataContext>()
                .As<DbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            //Singleton
            builder.RegisterInstance(Configuration)
                .As<IConfigurationRoot>()
                .SingleInstance()
                .ExternallyOwned();

            // Repository registration to autofac container
            builder.RegisterType<EFBrandRepository>().As<IBrandRepository>();
            builder.RegisterType<EFCultureRepository>().As<ICultureRepository>();
            builder.RegisterType<EFProductUserRepository>().As<IProductUserRepository>();
            builder.RegisterType<EFCategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<EFProductRepository>().As<IProductRepository>();
            builder.RegisterType<EFProductCategoryRepository>().As<IProductCategoryRepository>();
            builder.RegisterType<EFRatingRepository>().As<IRatingRepository>();
            builder.RegisterType<EFUserRepository>().As<IUserRepository>();

            builder.RegisterType<EFLocalizationRepository>().As<ILocalizationRepository>();

            // Service registration to autofac container
            builder.RegisterType<BrandService>().As<IBrandService>();
            builder.RegisterType<CartService>().As<ICartService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CultureService>().As<ICultureService>();
            builder.RegisterType<LocalizationService>().As<ILocalizationService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<RatingService>().As<IRatingService>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<JsonSerializerService>().As<ISerializer>();
            builder.RegisterType<DistributedCacheService>().As<ICacheService>();

            builder.RegisterType<AdminLocalizationControllerService>().As<IAdminLocalizationControllerService>();
            builder.RegisterType<HomeControllerService>().As<IHomeControllerService>();

            builder.RegisterType<LocalizationCache>().AsSelf();

            builder.RegisterType<AuthMessageSender>()
                .As<ISmsSender>()
                .As<IEmailSender>();

            builder.RegisterGeneric(typeof(DatabaseStringLocalizer<>))
                .As(typeof(IStringLocalizer<>));

            builder.RegisterType<DatabaseStringLocalizer<Startup>>()
                .As<IStringLocalizer>();

            
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }


        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
                using (var scope = ApplicationContainer.BeginLifetimeScope())
                {
                    var dataContext = scope.Resolve<DataContext>();
                    dataContext.Database.EnsureCreated();
                    dataContext.EnsureSeedData();
                }

                // When setting the REFRESH_LOCALE_CACHE to true, the class populates
                // the cache with the localized strings from the database.

                var refreshLocaleCacheEnvironment = Environment.GetEnvironmentVariable("REFRESH_LOCALE_CACHE");
                bool refreshLocale = refreshLocaleCacheEnvironment != null && refreshLocaleCacheEnvironment.ToLower().Equals("true");
                if (refreshLocale) {
                    using (var scope = ApplicationContainer.BeginLifetimeScope())
                    {
                        var localizationCache = scope.Resolve<LocalizationCache>();
                        localizationCache
                            .Populate();
                    }
                }
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = _supportedCultures,
                SupportedUICultures = _supportedCultures
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Disposing autofac container
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
