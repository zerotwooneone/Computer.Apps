using Computer.Bus.Domain.Contracts;
using System;

namespace Computer.Apps.ToDoList.Integration.Models;
#nullable enable
public class ItemModelMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.ItemModel)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ItemModel)) || obj == null)
        {
            return null;
        }

        var dto = obj as Computer.Apps.ToDoList.Integration.Models.ItemModel;
        if (dto == null)
        {
            return null;
        }

        return DtoToDomain(dto);
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.ItemModel)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.ItemModel)) || obj == null)
        {
            return null;
        }

        var domain = obj as Computer.Apps.ToDoList.Domain.Model.ItemModel;
        if (domain == null)
        {
            return null;
        }

        return DomainToDto(domain);
    }

    public Computer.Apps.ToDoList.Domain.Model.ItemModel DtoToDomain(Computer.Apps.ToDoList.Integration.Models.ItemModel dto)
    {
        return new ToDoList.Domain.Model.ItemModel
        {
            Text = dto.Text,
            Url = dto.Url,
            ImageUrl = dto.ImageUrl,
            Checked = dto.Checked ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.Checked' should not be null")
        };
    }

    public Computer.Apps.ToDoList.Integration.Models.ItemModel DomainToDto(Computer.Apps.ToDoList.Domain.Model.ItemModel domain)
    {
        return new ItemModel
        {
            Text = domain.Text,
            Url = domain.Url,
            ImageUrl = domain.ImageUrl,
            Checked = domain.Checked
        };
    }
}