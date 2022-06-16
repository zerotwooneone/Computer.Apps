using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Models;

[ProtoContract]
public class ListRequest
{
    [ProtoMember(1)]
    public string? Message { get; set; }
}