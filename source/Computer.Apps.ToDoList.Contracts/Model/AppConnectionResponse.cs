using ProtoBuf;

namespace Computer.Apps.ToDoList.Contracts.Model;

[ProtoContract]
public class AppConnectionResponse
{
    [ProtoMember(1)]
    public string InstanceId { get; init; }
}