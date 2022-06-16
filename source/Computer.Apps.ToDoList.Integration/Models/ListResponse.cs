using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Models;

[ProtoContract]
public class ListResponse
{
    [ProtoMember(1)]
    public string? Message { get; set; }
}