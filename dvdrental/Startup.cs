using dvdrental.Database.Repositories;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Domain.Interfaces.Services;
using dvdrental.Entities;
using dvdrental.Service;
using dvdrental.Service.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace dvdrental
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
            services.AddDbContext<DvdrentalContext>(options => options.UseNpgsql(Configuration.GetConnectionString("RemoteDatabase")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dvdrental", Version = "v1" });
            });

            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ErrorHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dvdrental v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

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
