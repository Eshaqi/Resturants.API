using FluentAssertions;
using Restaurants.Domain.Constants;
using Xunit;

namespace Restaurants.Application.User.Tests;

public class CurrentUserTests
{
    //TestMethod_WithMatchingRole_ExpectResult()
    [Theory()]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRoleTest_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        // arrangee
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);
        // act 
        var isInRole = currentUser.IsInRole(roleName);
        // assert
        isInRole.Should().BeTrue();
    }

    [Fact()]
    public void IsInRoleTest_WithNoMatchingRole_ShouldReturnFalse()
    {
        // arrangee
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);
        // act 
        var isInRole = currentUser.IsInRole(UserRoles.Owner);
        // assert
        isInRole.Should().BeFalse();
    }

    [Fact()]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        // arrange
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        // act

        var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

        // assert

        isInRole.Should().BeFalse();

    }  
}