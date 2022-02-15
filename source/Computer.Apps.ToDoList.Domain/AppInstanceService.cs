using Computer.Apps.ToDoList.Domain.Bus;
using Computer.Apps.ToDoList.Domain.Model;
using Computer.Bus.Domain.Contracts;
using IBus = Computer.Bus.Domain.Contracts.IBus;

namespace Computer.Apps.ToDoList.Domain;

public class AppInstanceService
{
    private readonly IBus _bus;
    private readonly IRequestService _requestService;
    private readonly List<IDisposable> _subscriptions = new();

    public AppInstanceService(IBus bus,
        IRequestService requestService)
    {
        _bus = bus;
        _requestService = requestService;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriptions.AddRange(new []
        {
            await _bus.Subscribe<AppConnectionRequest>(Events.GetConnection, OnAppConnectionRequest),
            _requestService.Listen<DefaultListRequest, DefaultListResponse>(Events.DefaultListRequest, Events.DefaultListResponse, OnDefaultListRequest),
        });
        //await _busClient.Subscribe<AppDisconnectRequest>(Events.CloseConnection, OnAppDisconnectionRequest);
        //await _busClient.Subscribe<GetListRequest>(Events.GetListRequest, OnGetListRequest);
    }

    private Task<DefaultListResponse?> OnDefaultListRequest(DefaultListRequest? param, string eventId, string correlationId)
    {
        return Task.FromResult<DefaultListResponse?>(new DefaultListResponse { List = null, Success = false });
    }

    private async Task OnGetListRequest(GetListRequest? param, string eventid, string correlationid)
    {
        var response = new GetListResponse
        {
            Version = (int)(DateTime.Now.Ticks % int.MaxValue)
        };
        var result = await _bus.Publish<GetListResponse>(
            Events.GetListResponse,
            response,
            eventId: null,
            correlationid);
    }

    private async Task OnAppDisconnectionRequest(AppDisconnectRequest? param, string eventid, string correlationid)
    {
        var response = new AppDisconnectResponse { };
        var result = await _bus.Publish<AppDisconnectResponse>(
            Events.CloseConnection,
            response,
            eventId: null,
            correlationid);
    }

    private async Task OnAppConnectionRequest(AppConnectionRequest? param, string eventid, string correlationid)
    {
        var response = new AppConnectionResponse { InstanceId = param?.InstanceId ?? Guid.NewGuid().ToString() };
        var result = await _bus.Publish<AppConnectionResponse>(
            Events.GetConnectionResponse,
            response,
            eventId: null,
            correlationid);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        var subscriptions = _subscriptions.ToArray();
        _subscriptions.Clear();
        foreach (var subscription in subscriptions)
        {
            try
            {
                subscription?.Dispose();
            }
            catch 
            {
                //ignore
            }
        }
        return Task.CompletedTask;
    }
}