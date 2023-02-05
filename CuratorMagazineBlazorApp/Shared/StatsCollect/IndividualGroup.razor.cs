using API.Models.Entities.Domains;
using WebClient.Data.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace WebClient.Shared.StatsCollect;

/// <summary>
/// Class IndividualGroup.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class IndividualGroup
{
    /// <summary>
    /// Gets or sets the group.
    /// </summary>
    /// <value>The group.</value>
    [Parameter]
    public Group? Group { get; set; }

    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    /// <value>The current user.</value>
    [Parameter]
    public User? CurrentUser { get; set; }

    /// <summary>
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    public GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the curator.
    /// </summary>
    /// <value>The curator.</value>
    private User? Curator { get; set; }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        if (Group != null)
        {
            var ret = await GroupService?.GetGroupCuratorAsync(Group.Id)!;

            Curator = ret.Result != null && ret.Result.Id != 0 ? JsonConvert.DeserializeObject<User>(ret.Result?.ToString() ?? string.Empty) : new User() { Name = "Нет куратора" };
        }
    }
}