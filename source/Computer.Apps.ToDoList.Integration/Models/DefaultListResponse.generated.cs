using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Models;
[ProtoContract]
#nullable enable
public class DefaultListResponse
{
    [ProtoMember(1)]
    public bool? Success { get; init; }

    [ProtoMember(2)]
    public ListModel? List { get; init; }
}