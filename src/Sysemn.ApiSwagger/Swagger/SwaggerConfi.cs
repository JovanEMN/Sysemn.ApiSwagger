using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace Sysemn.ApiSwagger.Swagger
{
    public static class SwaggerConfi
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Sysemn.ApiSwagger",
                    Description = "Exemplo de uso de swagger em AspNet Core WebApi.",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Jovan Oliveira Neves", Email = "jovan_emn@outlook.com", Url = "https://github.com/jovanemn" },
                    License = new License { Name = "MIT", Url = "https://github.com/jovanemn" }                    
                });                
            });
        }
    }
}
