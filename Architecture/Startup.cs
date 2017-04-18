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
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Architecture.Services.Product;
using Architecture.Repositories.Product;
using Architecture.Repositories.EntityFramework;
using Architecture.Repositories.Shared;
using Architecture.Repositories.Category;
using Architecture.Services.Category;

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

            //if(useSqlite){
            //    services.AddDbContext<IdentityContext>(
            //        options =>
            //            options.UseSqlite(
            //                "Data Source=../../../../Database/cas.db"
            //            )
            //    );
            //    services.AddDbContext<DataContext>(
            //        options =>
            //            options.UseSqlite(
            //                "Data Source=../../../../Database/cas.db"
            //            )
            //    );
            //}
            //else{
            //    services.AddDbContext<IdentityContext>(
            //        options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //    );
            //    services.AddDbContext<DataContext>(
            //        options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //    );
            //}
            // Add framework services.

            services.AddSingleton(Configuration);

            services.AddScoped<IdentityContext, IdentityContext>();
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<DbContext, DataContext>();


            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityContext, int>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();

            services.AddMvc();

            // Autofac container
            var builder = new ContainerBuilder();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IReadProductService, ReadProductService>();
            services.AddTransient<IWriteProductService, WriteProductService>();

            services.AddTransient<IProductCategoryRepository, EFProductCategoryRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<IReadCategoryService, ReadCategoryService>();
            services.AddTransient<IWriteCategoryService, WriteCategoryService>();

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();
                dataContext.Database.EnsureCreated();
                dataContext.EnsureSeedData();
            }

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

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
