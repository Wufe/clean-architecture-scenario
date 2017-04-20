using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Architecture.Services.Common;
using Architecture.Database;
using Architecture.Database.Entities;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Architecture.Repositories.Product;
using Architecture.Repositories.EntityFramework;
using Architecture.Repositories.Shared;
using Architecture.Repositories.Category;
using Architecture.Mappers.Common;
using Architecture.Repositories.Brand;
using Architecture.Repositories.Rating;
using Architecture.Services.ProductService;
using Architecture.Services.CategoryService;
using Architecture.Services.BrandService;
using Architecture.Services.RatingService;
using Architecture.Repositories.Cart;
using Architecture.Services.UserService;
using Architecture.Repositories.User;

namespace Architecture
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            _environment = env;

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

            var useSqliteEnvironment = Environment.GetEnvironmentVariable("USE_SQLITE");
            bool useSqlite = useSqliteEnvironment != null && useSqliteEnvironment.ToLower().Equals("true");

            services.AddAutoMapper(MappingConfiguration.Configure);

            services.AddMvc();

            // Autofac container
            var builder = new ContainerBuilder();

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

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityContext, int>()
                .AddDefaultTokenProviders();

            // Repository registration to autofac container
            builder.RegisterType<EFBrandRepository>().As<IBrandRepository>();
            builder.RegisterType<EFCartRepository>().As<ICartRepository>();
            builder.RegisterType<EFCategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<EFProductRepository>().As<IProductRepository>();
            builder.RegisterType<EFProductCategoryRepository>().As<IProductCategoryRepository>();
            builder.RegisterType<EFRatingRepository>().As<IRatingRepository>();
            builder.RegisterType<EFUserRepository>().As<IUserRepository>();

            // Service registration to autofac container
            builder.RegisterType<ReadBrandService>().As<IBrandService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<RatingService>().As<IRatingService>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<AuthMessageSender>()
                .As<ISmsSender>()
                .As<IEmailSender>();

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
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
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Disposing autofac container
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}
