#nullable enable
using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Domain;
[ProtoContract]
public partial class AppConnectionResponse
{
    [ProtoMember(1)]
    public string InstanceId { get; init; }
}