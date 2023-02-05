using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Shared.Curator;

/// <summary>
/// Class WorkWithGroup.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class WorkWithGroup
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
    /// The groups
    /// </summary>
    private List<Group>? _groups = new ();

    /// <summary>
    /// Deletes the group.
    /// </summary>
    /// <param name="user">The user.</param>
    void DeleteGroup(User user)
    {

    }

    /// <summary>
    /// Adds the group.
    /// </summary>
    /// <param name="user">The user.</param>
    void AddGroup(User user)
    {

    }

    /// <summary>
    /// Gets the groups.
    /// </summary>
    async Task GetGroups()
    {
        _groups = new List<Group>();
        var groups = await UserService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);
    }
}