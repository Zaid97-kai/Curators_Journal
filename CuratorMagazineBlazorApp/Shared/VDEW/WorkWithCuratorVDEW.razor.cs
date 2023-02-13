using API.Models.Entities.Domains;
using WebClient.Data.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace WebClient.Shared.VDEW;

/// <summary>
/// Class WorkWithCuratorVDEW.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class WorkWithCuratorVDEW
{
    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    /// <value>The current user.</value>
    [Parameter]
    public User? CurrentUser { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// The users
    /// </summary>
    private List<User>? _curators = new();

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible modal add curator window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible modal add curator window; otherwise, <c>false</c>.</value>
    private bool IsVisibleModalAddCuratorWindow { get; set; }

    /// <summary>
    /// Deletes the curator.
    /// </summary>
    /// <param name="user">The user.</param>
    void DeleteCurator(User user)
    {

    }

    /// <summary>
    /// Adds the curator.
    /// </summary>
    /// <param name="user">The user.</param>
    void AddCurator(User user)
    {

    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var users = await UserService?.PostAsync()!;
        _curators = JsonConvert.DeserializeObject<List<User>>(users.Result.Items?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Modals the add curator window.
    /// </summary>
    public void ModalAddCuratorWindow()
    {
        IsVisibleModalAddCuratorWindow = !IsVisibleModalAddCuratorWindow;
    }

    public void ShowModalAddCuratorWindowParam(bool value)
    {
        IsVisibleModalAddCuratorWindow = value;
    }
}