namespace Computer.Apps.ToDoList.Domain.Model;

public class GetListResponse
{
    public List<ListItem>? Items { get; init; }
    public List<DeltaItem>? Delta { get; init; }
    public int Version { get; init; }
}