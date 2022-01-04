using Computer.Apps.ToDoList.Domain;
using Computer.Apps.ToDoList.Integration.Domain.Config;
using Computer.Bus.Domain;
using Computer.Bus.Domain.Contracts;
using Microsoft.Extensions.Options;

namespace Computer.Apps.ToDoList.Integration.Domain;

public class DomainStartupService : IHostedService
{
    private readonly AppInstanceService _appInstanceService;
    private readonly DomainMapRegistrationService _domainMapRegistrationService;
    private readonly IOptions<BusConfig> _busConfig;
    private readonly Initializer _initializer;

    public DomainStartupService(AppInstanceService appInstanceService,
        DomainMapRegistrationService domainMapRegistrationService,
        IOptions<BusConfig> busConfig,
        Initializer initializer)
    {
        _appInstanceService = appInstanceService;
        _domainMapRegistrationService = domainMapRegistrationService;
        _busConfig = busConfig;
        _initializer = initializer;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (_busConfig.Value?.Subjects == null)
        {
            throw new InvalidDataException("Bus config subjects not found");
        }
        if (_busConfig.Value?.Maps == null )
        {
            throw new InvalidDataException("Bus config maps not found");
        }
        var maps = _busConfig.Value.Maps
            .Aggregate(new List<MapRegistration>(), (list,config) =>
            {
                if (config == null ||
                    string.IsNullOrWhiteSpace(config.Domain) ||
                    string.IsNullOrWhiteSpace(config.Dto) ||
                    string.IsNullOrWhiteSpace(config.Mapper))
                {
                    return list;
                }

                var domain = Type.GetType(config.Domain);
                var dto = Type.GetType(config.Dto);
                var mapper = Type.GetType(config.Mapper);
                if (domain == null ||
                    dto == null ||
                    mapper == null)
                {
                    return list;
                }

                var mapRegistration = new MapRegistration(domain, dto, mapper);
                list.Add(mapRegistration);
                return list;
            });
        var subjects = _busConfig.Value.Subjects.Aggregate(new List<ISubjectRegistration>(), (list, config) =>
        {
            var type = string.IsNullOrWhiteSpace(config.Value)
                ? null
                : Type.GetType(config.Value);
            list.Add(new SubjectRegistration(config.Key, type));
            return list;
        });
        
        _initializer.Register(subjects, maps);
        var mapperTypes = maps.Select(m => m.Mapper);
        _domainMapRegistrationService.Register(mapperTypes);
        await _appInstanceService.StartAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _appInstanceService.StopAsync(cancellationToken);
    }
}

record MapRegistration(Type Domain, Type Dto, Type Mapper) : IMapRegistration;
record SubjectRegistration(string SubjectName, Type? Type) : ISubjectRegistration;