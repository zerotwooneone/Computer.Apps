using ProtoBuf;

namespace Computer.Apps.ToDoList.Contracts.Model;

[ProtoContract]
public class ListItem
{
    
    [ProtoMember(1)]
    public string Id { get; init; }
    [ProtoMember(2)]
    public int Index { get; init; }
    [ProtoMember(3)]
    public bool Checked { get; init; }
    [ProtoMember(4)]
    public string? Text { get; init; }
    [ProtoMember(5)]
    public string? LinkUrl { get; init; }
    [ProtoMember(6)]
    public string? ImageUrl { get; init; }
}