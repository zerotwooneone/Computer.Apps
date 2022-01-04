using Computer.Apps.ToDoList.Domain;
using Computer.Apps.ToDoList.Integration.Domain.Config;
using Computer.Bus.Domain;
using Computer.Bus.Domain.Contracts;

namespace Computer.Apps.ToDoList.Integration.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var configurationSection = configuration.GetSection("Bus");
        serviceCollection.Configure<BusConfig>(configurationSection);
        serviceCollection.AddSingleton<IBus, Computer.Bus.Domain.Bus>();
        serviceCollection.AddSingleton<Initializer>(new Initializer());
        serviceCollection.AddSingleton<IMapperFactory, MapperFactory>();
        serviceCollection.AddSingleton<DomainMapRegistrationService>();
        serviceCollection.AddSingleton<AppInstanceService>();
        
        serviceCollection.AddHostedService<DomainStartupService>();

        return serviceCollection;
    }
}