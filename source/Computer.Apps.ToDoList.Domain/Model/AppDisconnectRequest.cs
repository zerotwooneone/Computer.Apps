namespace Computer.Apps.ToDoList.Domain.Model;

public class AppDisconnectRequest
{
    public string InstanceId { get; init; }
    public string AppId { get; init; }
}