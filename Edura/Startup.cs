using Edura.Repository.Abstraction;
using Edura.Repository.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edura
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EduraContext>
          (options => options.UseSqlServer(Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection")));
            services.AddTransient<IProductRepository, EfProductRepository>();
            services.AddTransient<ICategoryRepository, EfCategoryRepository>();
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            // app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "products",
                   template: "products/{category?}",
                   defaults:new { controller="Product",action="List" }
                   );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
