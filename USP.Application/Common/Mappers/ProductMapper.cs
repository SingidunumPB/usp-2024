using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP.Application.Common.Dto;
using USP.Domain.Entities;

namespace USP.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static async Task<ProductDetailsDto> ToDtoAsync(this Product entity)
    {
        var userDetails = await entity.ReferencedOneToOneUser.ToEntityAsync();
        var userDetailsDto = userDetails.ToDto();

        return new ProductDetailsDto(entity.Name, entity.Description, entity.Price, userDetailsDto,
            entity.ReferencedOneToManyUser.ToListDto(), entity.ReferencedManyToManyUser.ToListDto());
    }

    public static ProductCustomDetailsDto ToCustomDto(this Product entity)
    {
        return new ProductCustomDetailsDto(entity.Name + " - " + entity.Price);
    }

    public static Product ToEntityFromCreateDto(this ProductCreateDto dto, User user,
        One<User> referencedOneToOneUser)
    {
        var entity = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            // Category = Category.FromValue(dto.Category),
            User = user,
            ReferencedOneToOneUser = referencedOneToOneUser
        };

        return entity;
    }

    public static async Task<ProductEmbedded> ToEmbedded(this Product entity)
    {
        return new ProductEmbedded
        {
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            User = entity.User,
            ReferencedOneToOneUser = await entity.ReferencedOneToOneUser.ToEntityAsync(),
            ReferencedOneToManyUser = entity.ReferencedOneToManyUser.ToListEntity(),
            ReferencedManyToManyUser = entity.ReferencedManyToManyUser.ToListEntity()
        };
    }
}