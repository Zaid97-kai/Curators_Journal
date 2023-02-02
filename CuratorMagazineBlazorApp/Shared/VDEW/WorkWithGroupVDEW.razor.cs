using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Group = CuratorMagazineWebAPI.Models.Entities.Domains.Group;

namespace CuratorMagazineBlazorApp.Shared.VDEW;

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
    private List<Group>? Groups { get; set; }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await GroupService?.PostAsync()!;
        Groups = JsonConvert.DeserializeObject<List<CuratorMagazineWebAPI.Models.Entities.Domains.Group>>(ret.Result.Items?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Deletes the group.
    /// </summary>
    /// <param name="group">The group.</param>
    void DeleteGroup(Group group)
    {

    }

    /// <summary>
    /// Adds the group.
    /// </summary>
    /// <param name="group">The group.</param>
    void AddGroup(Group group)
    {

    }
    /// <summary>
    /// Gets the groups.
    /// </summary>
    public async Task GetGroups()
    {
        //Groups = new List<Group>();
        //var groups = await UserService.PostAsync();
        //Groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);
    }
}