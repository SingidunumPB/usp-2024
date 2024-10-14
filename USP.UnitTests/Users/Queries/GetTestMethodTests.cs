using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.BaseTests;

namespace USP.UnitTests.Users.Queries;

public class GetTestMethodTests : Base
{
    [Fact]
    public async Task User_Get_Test()
    {
        //Given (Arrange) - what is part of request
        
    
        //When (Act) - what we do with that data
        var response = await AnonymousClient.GetAsync("api/User/Test");
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
        
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}