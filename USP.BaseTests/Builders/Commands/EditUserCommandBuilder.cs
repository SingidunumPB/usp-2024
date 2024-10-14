using USP.Application.Common.Dto;
using USP.Application.Users.Commands;
using USP.BaseTests.Builders.Dto;

namespace USP.BaseTests.Builders.Commands;

public class EditUserCommandBuilder
{
    private EditUserDto _dto = new EditUserDtoBuilder().Build();

    public EditUserCommand Build() => new(_dto);

    public EditUserCommandBuilder WithDto(EditUserDto dto)
    {
        _dto = dto;
        return this;
    }
}