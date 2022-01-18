using Computer.Bus.Domain.Contracts;
using System;

namespace Computer.Apps.ToDoList.Integration.Models;
#nullable enable
public class DefaultListResponseMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.DefaultListResponse)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.DefaultListResponse)) || obj == null)
        {
            return null;
        }

        var dto = obj as Computer.Apps.ToDoList.Integration.Models.DefaultListResponse;
        if (dto == null)
        {
            return null;
        }

        return DtoToDomain(dto);
    }

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.DefaultListResponse)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.DefaultListResponse)) || obj == null)
        {
            return null;
        }

        var domain = obj as Computer.Apps.ToDoList.Domain.Model.DefaultListResponse;
        if (domain == null)
        {
            return null;
        }

        return DomainToDto(domain);
    }

    public Computer.Apps.ToDoList.Domain.Model.DefaultListResponse DtoToDomain(Computer.Apps.ToDoList.Integration.Models.DefaultListResponse dto)
    {
        return new ToDoList.Domain.Model.DefaultListResponse
        {
            Success = dto.Success ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.Success' should not be null"),
            List = dto.List != null ? new ToDoList.Domain.Model.ListModel
            {
                Id = dto.List.Id ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.List.Id' should not be null"),
                Items = dto.List.Items?.Select(dtoListItem => new ToDoList.Domain.Model.ItemModel
                {
                    Text = dtoListItem.Text,
                    Url = dtoListItem.Url,
                    ImageUrl = dtoListItem.ImageUrl,
                    Checked = dtoListItem.Checked ?? throw new ArgumentNullException(nameof(dtoListItem), "The value of 'dtoListItem.Checked' should not be null")
                }) ?? throw new ArgumentNullException(nameof(dto), "The value of 'dto.List.Items' should not be null")
            } : null
        };
    }

    public Computer.Apps.ToDoList.Integration.Models.DefaultListResponse DomainToDto(Computer.Apps.ToDoList.Domain.Model.DefaultListResponse domain)
    {
        return new DefaultListResponse
        {
            Success = domain.Success,
            List = domain.List != null ? new ListModel
            {
                Id = domain.List.Id,
                Items = domain.List.Items.Select(domainListItem => new ItemModel
                {
                    Text = domainListItem.Text,
                    Url = domainListItem.Url,
                    ImageUrl = domainListItem.ImageUrl,
                    Checked = domainListItem.Checked
                })
            } : null
        };
    }
}