using Computer.Bus.Domain.Contracts;
using System;

namespace Computer.Apps.ToDoList.Integration.Models;
#nullable enable
public class ListModelMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.ListModel)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ListModel)) || obj == null)
        {
            return null;
        }

        var dto = obj as Computer.Apps.ToDoList.Integration.Models.ListModel;
        if (dto == null)
        {
            return null;
        }

        return DtoToDomain(dto);
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.ListModel)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ListModel)) || obj == null)
        {
            return null;
        }

        var domain = obj as Computer.Apps.ToDoList.Domain.Model.ListModel;
        if (domain == null)
        {
            return null;
        }

        return DomainToDto(domain);
    }

    public Computer.Apps.ToDoList.Domain.Model.ListModel DtoToDomain(Computer.Apps.ToDoList.Integration.Models.ListModel dto)
    {
        return new ToDoList.Domain.Model.ListModel
        {
            Id = dto.Id ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.Id' should not be null"),
            Items = dto.Items?.Select(dtoItem => new ToDoList.Domain.Model.ItemModel
            {
                Text = dtoItem.Text,
                Url = dtoItem.Url,
                ImageUrl = dtoItem.ImageUrl,
                Checked = dtoItem.Checked ?? throw new ArgumentNullException(nameof(dtoItem), "The value of 'dtoItem.Checked' should not be null")
            }) ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.Items' should not be null")
        };
    }

    public Computer.Apps.ToDoList.Integration.Models.ListModel DomainToDto(Computer.Apps.ToDoList.Domain.Model.ListModel domain)
    {
        return new ListModel
        {
            Id = domain.Id,
            Items = domain.Items.Select(domainItem => new ItemModel
            {
                Text = domainItem.Text,
                Url = domainItem.Url,
                ImageUrl = domainItem.ImageUrl,
                Checked = domainItem.Checked
            })
        };
    }
}