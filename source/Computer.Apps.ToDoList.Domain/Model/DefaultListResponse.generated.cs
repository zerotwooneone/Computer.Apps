namespace Computer.Apps.ToDoList.Domain.Model;
#nullable enable
public class DefaultListResponse
{
    public bool Success { get; init; }

    public ListModel? List { get; init; }
}