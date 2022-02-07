using Computer.Apps.ToDoList.Domain.Bus;
using Computer.Apps.ToDoList.Domain.Model;
using Computer.Bus.Domain.Contracts;
using IBus = Computer.Bus.Domain.Contracts.IBus;

namespace Computer.Apps.ToDoList.Domain;

public class AppInstanceService
{
    private readonly IBus _bus;
    private readonly List<IDisposable> _subscriptions = new();

    public AppInstanceService(IBus bus)
    {
        _bus = bus;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriptions.AddRange(new []
        {
            await _bus.Subscribe<AppConnectionRequest>(Events.GetConnection, OnAppConnectionRequest),
            await _bus.Subscribe<DefaultListRequest>(Events.DefaultListRequest, OnDefaultListRequest),
        });
        //await _busClient.Subscribe<AppDisconnectRequest>(Events.CloseConnection, OnAppDisconnectionRequest);
        //await _busClient.Subscribe<GetListRequest>(Events.GetListRequest, OnGetListRequest);
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
    
    private async Task OnDefaultListRequest(DefaultListRequest? param, string eventId, string correlationId)
    {
        if (param == null || string.IsNullOrWhiteSpace(param.UserId))
        {
            var result = await _bus.Publish(
                Events.DefaultListResponse,
                new DefaultListResponse { Success = false },
                eventId: null,
                correlationId: correlationId);
            return;
        }

        var result2 = await _bus.Publish(
            Events.DefaultListResponse,
            new DefaultListResponse { Success = true },
            eventId: null,
            correlationId: correlationId);
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