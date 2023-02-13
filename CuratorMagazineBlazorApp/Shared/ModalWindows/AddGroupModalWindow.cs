using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;
using System.Text.RegularExpressions;
using Group = API.Models.Entities.Domains.Group;

namespace WebClient.Shared.ModalWindows;

/// <summary>
/// Class AddGroupModalWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class AddGroupModalWindow
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="AddGroupModalWindow" /> is visible.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    /// <value>The current user.</value>
    [Parameter]
    public User? CurrentUser { get; set; }

    /// <summary>
    /// Gets or sets the change visible.
    /// </summary>
    /// <value>The change visible.</value>
    [Parameter]
    public EventCallback<bool> ChangeVisible { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    /// <summary>
    /// Gets or sets the selected curator.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedCuratorItem { get; set; }

    /// <summary>
    /// Gets or sets the selected curator.
    /// </summary>
    /// <value>The selected division.</value>
    private User? SelectedCurator { get; set; }

    /// <summary>
    /// The divisions
    /// </summary>
    /// <value>The curators.</value>
    private List<User>? Curators { get; set; }

    /// <summary>
    /// The group
    /// </summary>
    /// <value>The group.</value>
    private Group? Group { get; set; } = new Group();

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success: {JsonConvert.SerializeObject(Group)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed: {JsonConvert.SerializeObject(Group)}");

    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await UserService?.PostAsync()!;
        Curators = JsonConvert.DeserializeObject<List<User>>(ret.Result.Items?.ToString() ?? string.Empty);
        Curators = Curators?.Where(i => i.Role?.Name == "Curator").ToList();
    }

    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine(e);
        ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// on modal OK button is click, submit form manually
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    private async void HandleOkAsync(MouseEventArgs e)
    {
        await GroupService?.CreateAsync(Group)!;
        var gret = await GroupService?.PostAsync()!;
        var groups = JsonConvert.DeserializeObject<List<Group>>(gret.Result.Items?.ToString() ?? string.Empty);
        var group = groups?.FirstOrDefault(i => i.Name == Group?.Name);
        if (group != null && SelectedCurator != null)
        {
            SelectedCurator.GroupId = group.Id;
            await UserService?.PutAsync(SelectedCurator)!;
        }

        await ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// Called when [selected item changed handler].
    /// </summary>
    /// <param name="value">The value.</param>
    private void OnSelectedCuratorItemChangedHandler(User value)
    {
        SelectedCurator = value;
    }
}