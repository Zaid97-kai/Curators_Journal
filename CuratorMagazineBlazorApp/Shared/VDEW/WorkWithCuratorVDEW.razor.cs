using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CuratorMagazineBlazorApp.Shared.VDEW;

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

    protected override async Task OnInitializedAsync()
    {
        var users = await UserService?.PostAsync()!;
        _curators = JsonConvert.DeserializeObject<List<User>>(users.Result.Items?.ToString() ?? string.Empty);
    }

    public void ModalAddCuratorWindow()
    {
        if (IsVisibleModalAddCuratorWindow)
        {
            IsVisibleModalAddCuratorWindow = false;
        }
        else
        {
            IsVisibleModalAddCuratorWindow = true;
        }
    }
}