using Computer.Apps.ToDoList.Contracts.Bus;
using Computer.Apps.ToDoList.Contracts.Model;
using Computer.Bus.Contracts;

namespace Computer.Apps.ToDoList.Integration.Instance;

public class AppInstanceService : IHostedService
{
    private readonly IBusClient _busClient;

    public AppInstanceService(IBusClient busClient)
    {
        _busClient = busClient;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _busClient.Subscribe<AppConnectionRequest>(Events.GetConnection, OnAppConnectionRequest);
        await _busClient.Subscribe<AppDisconnectRequest>(Events.CloseConnection, OnAppDisconnectionRequest);
        await _busClient.Subscribe<GetListRequest>(Events.GetListRequest, OnGetListRequest);
    }

    private async Task OnGetListRequest(GetListRequest? param, string eventid, string correlationid)
    {
        var response = new GetListResponse
        {
            Version = (int)(DateTime.Now.Ticks % int.MaxValue)
        };
        var result = await _busClient.Publish<GetListResponse>(
            Events.GetListResponse,
            response,
            eventId: null,
            correlationid);
    }

    private async Task OnAppDisconnectionRequest(AppDisconnectRequest? param, string eventid, string correlationid)
    {
        var response = new AppDisconnectResponse { };
        var result = await _busClient.Publish<AppDisconnectResponse>(
            Events.CloseConnection,
            response,
            eventId: null,
            correlationid);
    }

    private async Task OnAppConnectionRequest(AppConnectionRequest? param, string eventid, string correlationid)
    {
        var response = new AppConnectionResponse { InstanceId = param?.InstanceId ?? Guid.NewGuid().ToString() };
        var result = await _busClient.Publish<AppConnectionResponse>(
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