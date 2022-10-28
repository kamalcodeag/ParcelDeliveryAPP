using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.Data.Contexts;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Data.ServicesRegistration
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParcelDeliveryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ParcelDelivery")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IParcelRepository, ParcelRepository>();
            return services;
        }
    }
}