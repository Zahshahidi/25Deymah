using Microsoft.Extensions.DependencyInjection;
using Wtt.Services.ApplicationServices;
using Wtt.Services.Interfaces;

namespace Wtt.Services.DI
{
    public static class ServiceExtensions
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IFoodReservationService, FoodReservationService>();
            services.AddTransient<IFoodService, FoodService>();
            services.AddTransient<IMissionService, MissionService>();
            services.AddTransient<IPresenceService, PresenceService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVacationService, VacationService>();
            //todo add other services
        }
    }
}
