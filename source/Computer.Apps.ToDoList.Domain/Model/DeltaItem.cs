namespace Computer.Apps.ToDoList.Domain.Model;

public class DeltaItem
{
    public string Id { get; init; }
    public bool? Checked { get; init; }
    public string? Text { get; init; }
    public string? LinkUrl { get; init; }
    public string? ImageUrl { get; init; }
    public bool? Deleted { get; init; }
    public int? Index { get; init; }
}