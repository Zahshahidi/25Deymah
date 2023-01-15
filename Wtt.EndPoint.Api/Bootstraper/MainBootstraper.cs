using Microsoft.EntityFrameworkCore;
using Wtt.DataAccess;
using Wtt.DataAccess.DbContexts;
using Wtt.DataAccess.DI;
using Wtt.Services.DI;

namespace Wtt.EndPoint.Api.Bootstraper
{
    public static class MainBootstraper
    {
        public static void InitBootstraper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceLayer();
            services.AddDataAccessLayer(configuration);            
        }



      

       



    }
}
