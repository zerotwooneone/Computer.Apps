using Computer.Apps.ToDoList.Domain.Bus;
using Computer.Apps.ToDoList.Domain.Model;
using Computer.Bus.Domain.Contracts;

namespace Computer.Apps.ToDoList.Domain;

public class AppInstanceService
{
    private readonly IBus _bus;

    public AppInstanceService(IBus bus)
    {
        _bus = bus;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _bus.Subscribe<AppConnectionRequest>(Events.GetConnection, OnAppConnectionRequest);
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

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}