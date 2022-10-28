using Identity.Logic.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Logic.ServicesRegistration
{
    public static class LogicServiceRegistration
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }
    }
}