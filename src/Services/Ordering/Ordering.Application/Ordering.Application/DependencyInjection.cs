using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
    {
        return services;
    }
}
