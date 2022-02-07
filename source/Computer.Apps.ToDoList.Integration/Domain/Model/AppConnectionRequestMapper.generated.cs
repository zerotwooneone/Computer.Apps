#nullable enable
using Computer.Bus.Domain.Contracts.Models;
using System;

namespace Computer.Apps.ToDoList.Integration.Domain;
public partial class AppConnectionRequestMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Domain.AppConnectionRequest)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.AppConnectionRequest)) || obj == null)
        {
            return null;
        }

        var dto = (Computer.Apps.ToDoList.Integration.Domain.AppConnectionRequest)obj;
        return new Computer.Apps.ToDoList.Domain.Model.AppConnectionRequest{InstanceId = dto.InstanceId, AppId = dto.AppId};
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Domain.AppConnectionRequest)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.AppConnectionRequest)) || obj == null)
        {
            return null;
        }

        var domain = (Computer.Apps.ToDoList.Domain.Model.AppConnectionRequest)obj;
        return new Computer.Apps.ToDoList.Integration.Domain.AppConnectionRequest{InstanceId = domain.InstanceId, AppId = domain.AppId};
    }
}