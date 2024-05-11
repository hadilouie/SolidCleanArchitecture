using Blazored.LocalStorage;
using HR.LeaveManagement.Blazor.UI.Contracts;
using HR.LeaveManagement.Blazor.UI.Providers;
using HR.LeaveManagement.Blazor.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.Blazor.UI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly IClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client,
        ILocalStorageService localStorageService,
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
    {
        _client = client;
        _localStorage = localStorageService;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);
            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                // Set claims in Blazor and login state
                await((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            return false;
        }
    }

    public async Task Logout()
    {
        // remove claims in Blazor and invalidate login state
        await((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
        var response = await _client.RegisterAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }
}
