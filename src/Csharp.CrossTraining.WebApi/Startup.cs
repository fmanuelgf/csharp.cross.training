namespace Csharp.CrossTraining.WebApi
{
    using Csharp.CrossTraining.Infrastructure.Repositories;
    using Csharp.CrossTraining.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.WebApi.Mappers;

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
            services.AddDbContext<AppDbContext>(opt =>
               opt.UseSqlite(Configuration.GetConnectionString("PersonsConnectionString")));

            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Pet>, GenericRepository<Pet>>();
            services.AddScoped<AppMapper>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.EnsureCreated();
        }
    }
}