
namespace Computer.Apps.ToDoList.Contracts.Bus;

public static class Events
{
    public static readonly string GetConnection = GetEventName("GetConnection");
    public static readonly string CloseConnection = GetEventName("CloseConnection");
    public static readonly string GetConnectionResponse = GetEventName("GetConnectionResponse");
    public static readonly string CloseConnectionResponse = GetEventName("CloseConnectionResponse");
    public static readonly string GetListRequest = GetEventName("GetListRequest");
    public static readonly string GetListResponse = GetEventName("GetListResponse");
    
    private static string GetEventName(string partialName)
    {
        return $"Computer.Apps.ToDoList.Contracts.Bus.Events.{partialName}";
    }
}