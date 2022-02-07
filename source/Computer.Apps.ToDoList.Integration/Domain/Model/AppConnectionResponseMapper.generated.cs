#nullable enable
using Computer.Bus.Domain.Contracts.Models;
using System;

namespace Computer.Apps.ToDoList.Integration.Domain;
public partial class AppConnectionResponseMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Domain.AppConnectionResponse)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.AppConnectionResponse)) || obj == null)
        {
            return null;
        }

        var dto = (Computer.Apps.ToDoList.Integration.Domain.AppConnectionResponse)obj;
        return new Computer.Apps.ToDoList.Domain.Model.AppConnectionResponse{InstanceId = dto.InstanceId};
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Domain.AppConnectionResponse)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.AppConnectionResponse)) || obj == null)
        {
            return null;
        }

        var domain = (Computer.Apps.ToDoList.Domain.Model.AppConnectionResponse)obj;
        return new Computer.Apps.ToDoList.Integration.Domain.AppConnectionResponse{InstanceId = domain.InstanceId};
    }
}