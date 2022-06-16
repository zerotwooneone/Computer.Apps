using Computer.Apps.ToDoList.Domain.Model;
using ProtoBuf;

namespace Computer.Apps.ToDoList.Integration.Models;

[ProtoContract]
public class ListEvent
{
    [ProtoMember(1)]
    public string? Message { get; set; }
}