namespace Computer.Apps.ToDoList.Integration.Domain.Config;

public class BusConfig
{
    public MapConfig[]? Maps { get; init; }
    public Dictionary<string, string?>? Subjects { get; init; }
}