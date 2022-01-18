using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Models;
[ProtoContract]
#nullable enable
public class DefaultListRequest
{
    [ProtoMember(1)]
    public string? UserId { get; init; } = "not set";
}