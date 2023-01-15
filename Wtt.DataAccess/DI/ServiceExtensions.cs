using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess.DbContexts;

namespace Wtt.DataAccess.DI
{
    public static class ServiceExtensions
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IWttDataAccess, WttDataAccess>();
            services.AddDbContext<WttDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("MainConnectionString")));

        }
    }
}
