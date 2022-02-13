using AutoMapper;
using FluentValidation.AspNetCore;
using HMS.Api.ServiceExtensions;
using HMS.Core;
using HMS.Data;
using HMS.Service.DTOs.RoomTypeDtos;
using HMS.Service.Profiles;
using HMS.Service.Services.Implementations;
using HMS.Service.Services.Interfaces;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api
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

            services.AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RoomTypePostDtoValidator>());

            //dotnet ef --startup-project ../HMS.Api migrations add InitialMigration
            services.AddDatabaseConnectionService(Configuration, "DefaultConnection");

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();

            services.AddSwaggerServiceExtension();

            services.AddMapperService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HMS.Api v1"));
            }

            app.AddExceptionHandlerService();

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
