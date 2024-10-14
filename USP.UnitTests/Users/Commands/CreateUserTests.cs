using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.BaseTests;
using USP.BaseTests.Builders.Commands;
using USP.BaseTests.Builders.Dto;

namespace USP.UnitTests.Users.Commands;

public class CreateUserTests : Base
{
    [Fact]
    public async Task CreateUserCommand_User_UserCreated()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Petar")
            .WithLastName("Bisevac")
            .WithEmail("pbisevac@singidunum.ac.rs")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidFirstName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithLastName("Bisevac")
            .WithEmail("pbisevac@singidunum.ac.rs")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidLastName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Petar")
            .WithEmail("pbisevac@singidunum.ac.rs")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidEmail_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Petar")
            .WithLastName("Bisevac")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}