using Sysemn.ApiSwagger.Models;
using Sysemn.ApiSwagger.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sysemn.ApiSwagger
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]);
            });

            //Swagger
            services.AddSwaggerConfig();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseMvc();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Sysemn.ApiSwagger API"); });
        }
    }
}
