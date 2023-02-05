using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using WebClient.Models.States;

namespace WebClient.Shared;

/// <summary>
/// Class RoleNavBar.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class RoleNavBar
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
    /// Changes the on work with vdew state role nav bar.
    /// </summary>
    public void ChangeOnWorkWithVDEWStateRoleNavBar()
    {
        StateRoleNavBar = new StateRoleNavBar() { RoleName = "WorkWithVDEW" };
        StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
    }

    /// <summary>
    /// Changes the on stats collect state role nav bar.
    /// </summary>
    public void ChangeOnStatsCollectStateRoleNavBar()
    {
        StateRoleNavBar = new StateRoleNavBar() { RoleName = "StatsCollect" };
        StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
    }

    /// <summary>
    /// Changes the on work with group vdew state role nav bar.
    /// </summary>
    public void ChangeOnWorkWithGroupVDEWStateRoleNavBar()
    {
        StateRoleNavBar = new StateRoleNavBar() { RoleName = "WorkWithGroupVDEW" };
        StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
    }

    /// <summary>
    /// Changes the on work with curator vdew state role nav bar.
    /// </summary>
    public void ChangeOnWorkWithCuratorVDEWStateRoleNavBar()
    {
        StateRoleNavBar = new StateRoleNavBar() { RoleName = "WorkWithCuratorVDEW" };
        StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
    }
}