using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests;

public static class AssertionsExtensions
{
    public static async Task ShouldThrowApiExceptionWithStatusCodeAsync<TResponse>(this Func<Task<TResponse>> response,
        int statusCode) where TResponse : class =>
        (await response.Should().ThrowAsync<ApiException>()).And.StatusCode.Should().Be(statusCode);
}