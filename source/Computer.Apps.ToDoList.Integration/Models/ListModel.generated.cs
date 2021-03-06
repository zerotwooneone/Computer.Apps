using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Models;
[ProtoContract]
#nullable enable
public class ListModel
{
    [ProtoMember(1)]
    public string? Id { get; set; } = "not set";
    [ProtoMember(2)]
    public IEnumerable<ItemModel>? Items { get; set; } = new ItemModel[]{};
}