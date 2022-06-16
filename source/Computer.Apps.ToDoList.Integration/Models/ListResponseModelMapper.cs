using Computer.Apps.ToDoList.Domain.Model;
using Computer.Bus.Domain.Contracts.Models;

namespace Computer.Apps.ToDoList.Integration.Models;

public class ListResponseModelMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(ListRequest)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ListRequest)) || obj == null)
        {
            return null;
        }

        var dto = obj as ListRequest;
        if (dto == null || string.IsNullOrWhiteSpace(dto.Message))
        {
            return null;
        }

        return DtoToDomain(dto);
    }

    private Computer.Apps.ToDoList.Domain.Model.ListRequest DtoToDomain(ListRequest dtoType)
    {
        return new Computer.Apps.ToDoList.Domain.Model.ListRequest
        {
            Message = dtoType.Message
        };
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(ListRequest)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ListRequest)) || obj == null)
        {
            return null;
        }

        var domain = obj as Computer.Apps.ToDoList.Domain.Model.ListRequest;
        if (domain == null || string.IsNullOrWhiteSpace(domain.Message))
        {
            return null;
        }

        return DomainToDto(domain);
    }

    private ListRequest DomainToDto(Computer.Apps.ToDoList.Domain.Model.ListRequest domainType)
    {
        return new ListRequest()
        {
            Message = domainType.Message
        };
    }
}