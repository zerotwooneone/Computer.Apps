#nullable enable
using Computer.Bus.Domain.Contracts;

namespace Computer.Apps.ToDoList.Integration.Domain;

public class DefaultListResponseMapper : IMapper
{
    public object? DtoToDomain(Type dtoType, object obj, Type domainType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.DefaultListResponse)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.DefaultListResponse)) || obj == null)
        {
            return null;
        }

        var dto = (Computer.Apps.ToDoList.Integration.Models.DefaultListResponse)obj;
        return DtoToDomain(dto);
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

    public object? DomainToDto(Type domainType, object obj, Type dtoType)
    {
        if (!dtoType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Integration.Models.DefaultListResponse)) || !domainType.IsAssignableFrom(typeof(Computer.Apps.ToDoList.Domain.Model.DefaultListResponse)) || obj == null)
        {
            return null;
        }

        var domain = (Computer.Apps.ToDoList.Domain.Model.DefaultListResponse)obj;
        return DomainToDto(domain);
    }

    public Computer.Apps.ToDoList.Integration.Models.DefaultListResponse DomainToDto(Computer.Apps.ToDoList.Domain.Model.DefaultListResponse domain)
    {
        return new Models.DefaultListResponse
        {
            Success = domain.Success,
            List = domain.List != null ? new Models.ListModel
            {
                Id = domain.List.Id,
                Items = domain.List.Items.Select(domainListItem => new Models.ItemModel
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