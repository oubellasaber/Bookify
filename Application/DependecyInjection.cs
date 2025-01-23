using Bookify.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly);
            });
            services.AddSingleton<PricingService>();
            return services;
        }
    }
}
