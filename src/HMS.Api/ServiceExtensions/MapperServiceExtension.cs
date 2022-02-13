using AutoMapper;
using HMS.Service.HelperServices.Interfaces;
using HMS.Service.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.ServiceExtensions
{
    public static class MapperServiceExtension
    {
        public static void AddMapperService(this IServiceCollection services)
        {

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile(provider.GetService<IHelperAccessor>()));
            }).CreateMapper());
        }
    }
}
