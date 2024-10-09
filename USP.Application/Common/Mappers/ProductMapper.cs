using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP.Application.Common.Dto;
using USP.Domain.Entities;
using USP.Domain.Enums;

namespace USP.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static partial ProductDetailsDto ToDto(this Domain.Entities.Product entity);

    public static ProductCustomDetailsDto ToCustomDto(this Domain.Entities.Product entity)
    {
        return new ProductCustomDetailsDto(entity.Name + " - " + entity.Price);
    }

    public static Domain.Entities.Product ToEntityFromCreateDto(this ProductCreateDto dto, User user, One<User> referencedOneToOneUser)
    {
        var entity = new Domain.Entities.Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Category = Category.FromValue(dto.Category),
            User = user,
            ReferencedOneToOneUser = referencedOneToOneUser
        };
        
        return entity;
    }
}