using ProtoBuf;

namespace Computer.Apps.ToDoList.Contracts.Model;

[ProtoContract]
public class AppConnectionRequest
{
    [ProtoMember(1)]
    public string InstanceId { get; init; }
    [ProtoMember(2)]
    public string AppId { get; init; }
}