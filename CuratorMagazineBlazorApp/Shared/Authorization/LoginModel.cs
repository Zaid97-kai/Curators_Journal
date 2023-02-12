using Microsoft.AspNetCore.Components;

namespace WebClient.Shared.Authorization
{
    /// <summary>
    /// Class LoginModal.
    /// Implements the <see cref="ComponentBase" />
    /// </summary>
    /// <seealso cref="ComponentBase" />
    public class LoginModel : ComponentBase
    {
        /// <summary>
        /// Gets or sets the local storage service.
        /// </summary>
        /// <value>The local storage service.</value>
        [Inject]
        ILocalStorageService localStorageService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public LoginViewModel Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginModal" /> class.
        /// </summary>
        public LoginModel()
        {
            Model = new LoginViewModel();
        }

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        protected async Task LoginAsync()
        {
            var token = new SecurityToken()
            {
                AccessToken = Model.Password,
                UserName = Model.UserName,
                ExpiredAt = DateTime.UtcNow.AddDays(1)
            };

            await localStorageService.SetAsync(nameof(SecurityToken), token);

            NavigationManager.NavigateTo("/", true);
        }
    }

    /// <summary>
    /// Class SecurityToken.
    /// </summary>
    public class SecurityToken
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the expired at.
        /// </summary>
        /// <value>The expired at.</value>
        public DateTime ExpiredAt { get; set; }
    }
}
