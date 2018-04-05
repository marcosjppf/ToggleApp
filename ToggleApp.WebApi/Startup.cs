using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToggleApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ToggleApp.Domain.Repositories;
using ToggleApp.Data.Repositories;
using ToggleApp.AppService.Implementations;
using ToggleApp.AppService.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace ToggleApp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToggleAppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IApplicationRepository, ApplicationRepository>();            
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IToggleRepository, ToggleRepository>();
            services.AddScoped<IToggleService, ToggleService>();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ToggleApp Web Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToggleApp Web Api");
            });

            app.UseMvc();
        }
    }
}
