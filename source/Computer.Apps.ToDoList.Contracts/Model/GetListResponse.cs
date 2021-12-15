using ProtoBuf;

namespace Computer.Apps.ToDoList.Contracts.Model;

[ProtoContract]
public class GetListResponse
{
    [ProtoMember(1)]
    public List<ListItem>? Items { get; init; }
    [ProtoMember(2)]
    public List<DeltaItem>? Delta { get; init; }
    [ProtoMember(3)]
    public int Version { get; init; }
}