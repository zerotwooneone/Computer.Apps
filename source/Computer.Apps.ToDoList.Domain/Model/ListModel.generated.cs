namespace Computer.Apps.ToDoList.Domain.Model;
#nullable enable
public class ListModel
{
    public string Id { get; set; } = "not set";
    public IEnumerable<ItemModel> Items { get; set; } = new ItemModel[]{};
}