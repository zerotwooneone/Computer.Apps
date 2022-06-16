using Computer.Bus.Domain.Contracts.Models;

namespace Computer.Apps.ToDoList.Integration.Models;

public class ListEventModelMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(ListEvent)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ListEvent)) || obj == null)
        {
            return null;
        }

        var dto = obj as ListEvent;
        if (dto == null || string.IsNullOrWhiteSpace(dto.Message))
        {
            return null;
        }

        return DtoToDomain(dto);
    }

    private Computer.Apps.ToDoList.Domain.Model.ListEvent DtoToDomain(ListEvent dtoType)
    {
        return new Computer.Apps.ToDoList.Domain.Model.ListEvent
        {
            Message = dtoType.Message
        };
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(ListEvent)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ListEvent)) || obj == null)
        {
            return null;
        }

        var domain = obj as Computer.Apps.ToDoList.Domain.Model.ListEvent;
        if (domain == null || string.IsNullOrWhiteSpace(domain.Message))
        {
            return null;
        }

        return DomainToDto(domain);
    }

    private ListEvent DomainToDto(Computer.Apps.ToDoList.Domain.Model.ListEvent domainType)
    {
        return new ListEvent()
        {
            Message = domainType.Message
        };
    }
}