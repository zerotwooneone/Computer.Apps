using Computer.Bus.Domain.Contracts.Models;
using System;

namespace Computer.Apps.ToDoList.Integration.Models;
#nullable enable
public class DefaultListRequestMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.DefaultListRequest)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.DefaultListRequest)) || obj == null)
        {
            return null;
        }

        var dto = obj as Computer.Apps.ToDoList.Integration.Models.DefaultListRequest;
        if (dto == null)
        {
            return null;
        }

        return DtoToDomain(dto);
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.DefaultListRequest)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.DefaultListRequest)) || obj == null)
        {
            return null;
        }

        var domain = obj as Computer.Apps.ToDoList.Domain.Model.DefaultListRequest;
        if (domain == null)
        {
            return null;
        }

        return DomainToDto(domain);
    }

    public Computer.Apps.ToDoList.Domain.Model.DefaultListRequest DtoToDomain(Computer.Apps.ToDoList.Integration.Models.DefaultListRequest dto)
    {
        return new ToDoList.Domain.Model.DefaultListRequest
        {
            UserId = dto.UserId ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.UserId' should not be null")
        };
    }

    public Computer.Apps.ToDoList.Integration.Models.DefaultListRequest DomainToDto(Computer.Apps.ToDoList.Domain.Model.DefaultListRequest domain)
    {
        return new DefaultListRequest
        {
            UserId = domain.UserId
        };
    }
}