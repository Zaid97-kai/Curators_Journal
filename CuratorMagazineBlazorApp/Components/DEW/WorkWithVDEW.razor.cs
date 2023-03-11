using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;
using WebClient.Models.States;

namespace WebClient.Components.DEW;

/// <summary>
/// Class WorkWithVDEW.
/// </summary>
public partial class WorkWithVDEW
{
    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    /// <value>The current user.</value>
    [Parameter]
    public User? CurrentUser { get; set; }

    /// <summary>
    /// Gets or sets the state role nav bar.
    /// </summary>
    /// <value>The state role nav bar.</value>
    [Parameter]
    public StateRoleNavBar? StateRoleNavBar { get; set; } = new();

    /// <summary>
    /// Gets or sets the state role nav bar callback.
    /// </summary>
    /// <value>The state role nav bar callback.</value>
    [Parameter]
    public EventCallback<StateRoleNavBar> StateRoleNavBarCallback { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// The users
    /// </summary>
    private List<User>? _users = new();

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible modal add vdew window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible modal add vdew window; otherwise, <c>false</c>.</value>
    private bool IsVisibleModalAddVdewWindow { get; set; }

    /// <summary>
    /// Deletes the vdew.
    /// </summary>
    /// <param name="user">The user.</param>
    void DeleteVDEW(User user)
    {

    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var users = await UserService?.PostAsync()!;
        _users = JsonConvert.DeserializeObject<List<User>>(users.Result.Items?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Modals the add vdew window.
    /// </summary>
    public void ModalAddVdewWindow()
    {
        IsVisibleModalAddVdewWindow = !IsVisibleModalAddVdewWindow;
    }

    /// <summary>
    /// Modals the add vdew window.
    /// </summary>
    public void ModalAddVdewWindowParam(bool value)
    {
        IsVisibleModalAddVdewWindow = value;
    }
}