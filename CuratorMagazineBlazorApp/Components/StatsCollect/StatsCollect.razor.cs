using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Shared.Entities.Domains;
using WebClient.Data.Services;
using WebClient.Models.States;

namespace WebClient.Components.StatsCollect;

/// <summary>
/// Class StatsCollect.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class StatsCollect
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
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    public GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    public RoleService? RoleService { get; set; }

    /// <summary>
    /// The groups
    /// </summary>
    private List<Group>? _groups = new();

    /// <summary>
    /// The groups
    /// </summary>
    private List<Role>? _roles;

    /// <summary>
    /// The role
    /// </summary>
    private Role? _role;

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var groups = await GroupService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);

        var roles = await RoleService?.PostAsync()!;
        _roles = JsonConvert.DeserializeObject<List<Role>>(roles.Result.Items?.ToString() ?? string.Empty);
        
        if(_roles != null)
        {
            _role = _roles.FirstOrDefault(i => i.Name == "Curator"); ;
        }
    }

    /// <summary>
    /// Changes the on work with vdew state role nav bar.
    /// </summary>
    public void ChangeOnWorkWithVDEWStateRoleNavBar()
    {
        StateRoleNavBar = new StateRoleNavBar() { RoleName = "StatsCollectionPage" };
        StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
    }
}