using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using WebClient.Models.States;

namespace WebClient.Shared;

/// <summary>
/// Class HeaderComponent.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class HeaderComponent
{
    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    /// <value>The current user.</value>
    [Parameter]
    public User? CurrentUser { get; set; }

    /// <summary>
    /// Gets or sets the role callback.
    /// </summary>
    /// <value>The role callback.</value>
    [Parameter]
    public EventCallback<User?> RoleCallback { get; set; }

    /// <summary>
    /// Gets or sets the user null callback.
    /// </summary>
    /// <value>The user null callback.</value>
    [Parameter]
    public EventCallback<User> UserNullCallback { get; set; }

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
    /// Sets the user.
    /// </summary>
    /// <param name="user">The user.</param>
    public void SetUser(User? user)
    {
        CurrentUser = user;
        RoleCallback.InvokeAsync(user);
    }

    /// <summary>
    /// Sets the user null.
    /// </summary>
    public void SetUserNull()
    {
        CurrentUser = null;
        UserNullCallback.InvokeAsync();
    }

    /// <summary>
    /// Sets the state role nav bar.
    /// </summary>
    /// <param name="roleNavBar">The role nav bar.</param>
    public void SetStateRoleNavBar(StateRoleNavBar roleNavBar)
    {
        StateRoleNavBar = roleNavBar;
        StateRoleNavBarCallback.InvokeAsync(roleNavBar);
    }
}