using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Components.Curator;

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
    private List<Group>? _groups = new();

    /// <summary>
    /// Gets the groups.
    /// </summary>
    private async Task GetGroups()
    {
        var groups = await UserService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);
    }
}