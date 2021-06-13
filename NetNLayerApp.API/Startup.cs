using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetNLayerApp.API.Filters;
using NetNLayerApp.Core.Repositories;
using NetNLayerApp.Core.Services;
using NetNLayerApp.Core.UnitOfWorks;
using NetNLayerApp.Data;
using NetNLayerApp.Data.Repositories;
using NetNLayerApp.Data.UnitOfWorks;
using NetNLayerApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNLayerApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DI
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>(); //ctor di nesnesi aldigindan eklemek zorunlu.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            //AddScoped request esnasinda birden fazla ihtiyac olursa ayni nesneyi kullanir ama AddTransient olursa her karsilasmada nesne uretir, performans azalir.
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //IUnitOfWork karsilasirsa, UnitOfWork class yapisindan nesne ornegi olustur 
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("NetNLayerApp.Data");
                });
            });
            

            services.AddControllers();

            //services.AddControllers(o =>                  
            //{
            //    o.Filters.Add(new ValidationFilter());                filter yapisini global duzeyde controller yapilarina yedirme.
            //});

            //custom filter allow
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetNLayerApp.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetNLayerApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
