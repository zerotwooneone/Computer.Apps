using ProtoBuf;

namespace Computer.Apps.ToDoList.Contracts.Model;

[ProtoContract]
public class GetListRequest
{
    [ProtoMember(1)]
    public string ListId { get; init; }
    [ProtoMember(2)]
    public int? Version { get; init; }
}