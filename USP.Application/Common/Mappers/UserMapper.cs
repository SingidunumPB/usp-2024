using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP.Application.Common.Dto;
using USP.Domain.Entities;

namespace USP.Application.Common.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial UserDetailsDto ToDto(this User entity);
    public static partial User ToEntity(this UserDetailsDto dto);

    public static User ToEntity(this EditUserDto dto)
    {
        return new User
        {
            ID = (string.IsNullOrEmpty(dto.ID) ? null : dto.ID) ?? string.Empty,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
    }

    public static ListUserDetailsDto ToListDto(this Many<User, Domain.Entities.Product> manyEntities)
    {
        var listDto = new List<UserDetailsDto>();

        foreach (var entity in manyEntities)
        {
            listDto.Add(entity.ToDto());
        }

        return new ListUserDetailsDto(listDto);
    }
    
    public static List<User> ToListEntity(this Many<User, Domain.Entities.Product> manyEntities)
    {
        var list = new List<User>();

        foreach (var entity in manyEntities)
        {
            list.Add(entity);
        }

        return list;
    }
}