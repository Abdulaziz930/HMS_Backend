using HMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.ServiceExtensions
{
    public static class DatabaseConnectionExtension
    {
        public static void AddDatabaseConnectionService(this IServiceCollection services, IConfiguration configuration, string section)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(section));
            });
        }
    }
}
