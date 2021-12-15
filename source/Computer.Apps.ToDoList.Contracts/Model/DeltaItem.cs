using ProtoBuf;

namespace Computer.Apps.ToDoList.Contracts.Model;

[ProtoContract]
public class DeltaItem
{
    [ProtoMember(1)]
    public string Id { get; init; }
    [ProtoMember(2)]
    public bool? Checked { get; init; }
    [ProtoMember(3)]
    public string? Text { get; init; }
    [ProtoMember(4)]
    public string? LinkUrl { get; init; }
    [ProtoMember(5)]
    public string? ImageUrl { get; init; }
    [ProtoMember(6)]
    public bool? Deleted { get; init; }
    [ProtoMember(7)]
    public int? Index { get; init; }
}