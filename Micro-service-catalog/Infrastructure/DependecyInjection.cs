using FluentValidation;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Application.Common.Interfaces;

namespace Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IDeezerService, DeezerService>();

        services.AddScoped<ISolrService>(provider =>
        {
            return new SolrService(configuration.GetSection("Solr").GetSection("BaseUrl").Value);
        });

        return services;
    }
    
}
