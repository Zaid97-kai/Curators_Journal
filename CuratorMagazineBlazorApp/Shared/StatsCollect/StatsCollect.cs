﻿using API.Models.Entities.Domains;
using WebClient.Models.States;
using WebClient.Data.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace WebClient.Shared.StatsCollect;

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
    /// The groups
    /// </summary>
    private List<Group>? _groups;

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        _groups = new List<Group>();
        var groups = await GroupService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);
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