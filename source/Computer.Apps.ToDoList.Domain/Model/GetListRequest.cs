namespace Computer.Apps.ToDoList.Domain.Model;

public class GetListRequest
{
    public string ListId { get; init; }
    public int? Version { get; init; }
}