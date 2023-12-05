using FluentValidation;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Common.Interfaces;

namespace Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IDeezerService, DeezerService>();

        return services;
    }
    
}
