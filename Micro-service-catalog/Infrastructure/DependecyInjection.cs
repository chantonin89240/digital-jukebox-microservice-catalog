using FluentValidation;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Application.Common.Interfaces;
using Infrastructure.Data;
using MongoDB.Driver;

namespace Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IDeezerService, DeezerService>();

        //services.AddScoped<ISolrService>(provider =>
        //{
        //    return new SolrService(configuration.GetSection("Solr").GetSection("BaseUrl").Value);
        //});

        //var connectionString = "mongodb://root:root@localhost:27017/?retryWrites=true&w=majority";
        var connectionString = "mongodb+srv://toto:toto@clusterdigitaljukebox.yf8cuzj.mongodb.net/?connectTimeoutMS=120000&retryWrites=true&w=majority";
        var databaseName = "Catalog";
        services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));
        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(databaseName);
        });
        services.AddScoped<IMongoDbContext, MongoDbContext>();

        return services;
    }


}
