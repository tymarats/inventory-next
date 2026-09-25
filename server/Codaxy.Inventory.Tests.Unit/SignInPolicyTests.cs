using Codaxy.Inventory.Auth;
using Codaxy.Inventory.Setup;
using Microsoft.Extensions.Options;

namespace Codaxy.Inventory.Tests.Unit;

public class SignInPolicyTests
{
    private static SignInPolicy Policy(AuthOptions options) => new(Options.Create(options));

    [Fact]
    public void Allows_an_address_in_the_configured_domain()
    {
        var policy = Policy(new AuthOptions { Domain = "codaxy.com" });

        Assert.True(policy.Evaluate("someone@codaxy.com").IsAllowed);
    }

    [Fact]
    public void Refuses_an_address_outside_the_configured_domain()
    {
        var policy = Policy(new AuthOptions { Domain = "codaxy.com" });

        var result = policy.Evaluate("someone@example.com");

        Assert.False(result.IsAllowed);
        Assert.Contains("codaxy.com", result.Reason);
    }

    [Fact]
    public void Allows_any_domain_when_none_is_configured()
    {
        var policy = Policy(new AuthOptions());

        Assert.True(policy.Evaluate("someone@example.com").IsAllowed);
    }

    [Fact]
    public void Refuses_an_address_outside_a_non_empty_allow_list()
    {
        var policy = Policy(new AuthOptions { AllowedUsers = ["one@codaxy.com"] });

        Assert.False(policy.Evaluate("two@codaxy.com").IsAllowed);
        Assert.True(policy.Evaluate("one@codaxy.com").IsAllowed);
    }

    [Fact]
    public void Refuses_a_denied_address_even_when_it_is_also_allowed()
    {
        var policy = Policy(
            new AuthOptions { AllowedUsers = ["one@codaxy.com"], DeniedUsers = ["one@codaxy.com"] }
        );

        Assert.False(policy.Evaluate("one@codaxy.com").IsAllowed);
    }

    [Theory]
    [InlineData("SOMEONE@CODAXY.COM")]
    [InlineData(" someone@codaxy.com ")]
    public void Ignores_case_and_surrounding_space(string email)
    {
        var policy = Policy(
            new AuthOptions { Domain = "codaxy.com", AllowedUsers = ["someone@codaxy.com"] }
        );

        Assert.True(policy.Evaluate(email).IsAllowed);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Refuses_an_account_with_no_address(string? email)
    {
        Assert.False(Policy(new AuthOptions()).Evaluate(email).IsAllowed);
    }
}
