using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Users.Commands;

namespace USP.UnitTests.Users.Commands;

public class CreateUserTests : Base
{
    private const string BaseUrl = "/api/User/Edit";

    [Fact]
    public async Task GetUserPagedListQuery_Filters_ReturnUserPagedList()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDto("-", "-", "-", null);

        var requestBody = new StringContent(JsonSerializer.Serialize(new EditUserCommand(dto)),
            Encoding.UTF8,
            "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync(BaseUrl, requestBody);
        var response2 = await AnonymousClient.GetAsync("/api/User/Test");

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await DB.Database("UspTests").Client.DropDatabaseAsync("UspTests");
    }
}