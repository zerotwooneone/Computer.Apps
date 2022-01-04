#nullable enable
namespace Computer.Apps.ToDoList.Domain.Model;
public partial class AppConnectionRequest
{
    public string InstanceId { get; init; }

    public string AppId { get; init; }
}