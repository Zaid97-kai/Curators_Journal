using API.Models.Entities.Domains;
using Group = API.Models.Entities.Domains.Group;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Shared.VDEW;

/// <summary>
/// Class WorkWithGroupVDEW.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class WorkWithGroupVDEW
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
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    public GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the groups.
    /// </summary>
    /// <value>The groups.</value>
    private List<Group>? _groups { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible modal add group window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible modal add group window; otherwise, <c>false</c>.</value>
    private bool IsVisibleModalAddGroupWindow { get; set; }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await GroupService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(ret.Result.Items?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Modals the add group window.
    /// </summary>
    public void ModalAddGroupWindow()
    {
        IsVisibleModalAddGroupWindow = !IsVisibleModalAddGroupWindow;
    }
}