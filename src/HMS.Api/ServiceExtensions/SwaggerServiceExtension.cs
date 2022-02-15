using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace HMS.Api.ServiceExtensions
{
    public static class SwaggerServiceExtension
    {
        public static void AddSwaggerServiceExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HMS.Api", Version = "v1" });
                c.AddFluentValidationRulesScoped();
            });
        }
    }
}
