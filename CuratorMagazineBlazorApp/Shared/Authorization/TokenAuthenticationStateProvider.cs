using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebClient.Shared.Authorization;

/// <summary>
/// Class TokenAuthenticationStateProvider.
/// Implements the <see cref="AuthenticationStateProvider" />
/// </summary>
/// <seealso cref="AuthenticationStateProvider" />
public class TokenAuthenticationStateProvider : AuthenticationStateProvider
{
    /// <summary>
    /// The local storage service
    /// </summary>
    private readonly ILocalStorageService _localStorageService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenAuthenticationStateProvider" /> class.
    /// </summary>
    /// <param name="localStorageService">The local storage service.</param>
    public TokenAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    /// <summary>
    /// Creates the anonymous.
    /// </summary>
    /// <returns>AuthenticationState.</returns>
    private AuthenticationState CreateAnonymous()
    {
        var anonymousIdentity = new ClaimsIdentity();
        var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
        return new AuthenticationState(anonymousPrincipal);
    }

    /// <summary>
    /// Asynchronously gets an <see cref="T:Microsoft.AspNetCore.Components.Authorization.AuthenticationState" /> that describes the current user.
    /// </summary>
    /// <returns>A task that, when resolved, gives an <see cref="T:Microsoft.AspNetCore.Components.Authorization.AuthenticationState" /> instance that describes the current user.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        CreateAnonymous();

        var token = await _localStorageService.GetAsync<SecurityToken>(nameof(SecurityToken));

        if (token == null)
        {
            return CreateAnonymous();
        }

        if (string.IsNullOrEmpty(token.AccessToken) || token.ExpiredAt < DateTime.UtcNow)
        {
            return CreateAnonymous();
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Country, "Russia"),
            new Claim(ClaimTypes.Name, token.UserName),
            new Claim(ClaimTypes.Role, "Administrator"),
            new Claim(ClaimTypes.Role, "Manager"),
            new Claim(ClaimTypes.Expired, token.ExpiredAt.ToLongDateString()),
        };

        var identity = new ClaimsIdentity(claims, "Token");
        var principal = new ClaimsPrincipal(identity);
        return new AuthenticationState(principal);
    }
}

