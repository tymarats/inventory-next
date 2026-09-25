using Codaxy.Inventory.Setup;
using Microsoft.Extensions.Options;

namespace Codaxy.Inventory.Auth;

/// <summary>
/// Who is allowed in. There is no user table: membership is a deployment decision, so it is read
/// from configuration and applied to whichever provider the person came through.
/// </summary>
public sealed class SignInPolicy(IOptions<AuthOptions> options)
{
    private readonly AuthOptions options = options.Value;

    public SignInResult Evaluate(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return SignInResult.Refused("The account has no email address.");

        email = email.Trim();

        if (
            !string.IsNullOrWhiteSpace(options.Domain)
            && !email.EndsWith($"@{options.Domain}", StringComparison.OrdinalIgnoreCase)
        )
            return SignInResult.Refused($"Only {options.Domain} accounts may sign in.");

        if (options.DeniedUsers.Contains(email, StringComparer.OrdinalIgnoreCase))
            return SignInResult.Refused("This account is not allowed to sign in.");

        if (
            options.AllowedUsers.Length > 0
            && !options.AllowedUsers.Contains(email, StringComparer.OrdinalIgnoreCase)
        )
            return SignInResult.Refused("This account is not allowed to sign in.");

        return SignInResult.Allowed;
    }

    public readonly record struct SignInResult(bool IsAllowed, string? Reason)
    {
        public static SignInResult Allowed { get; } = new(true, null);

        public static SignInResult Refused(string reason) => new(false, reason);
    }
}
