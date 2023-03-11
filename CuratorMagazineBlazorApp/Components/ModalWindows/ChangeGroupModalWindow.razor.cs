using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using Shared.Entities.Domains;
using WebClient.Data.Services;

namespace WebClient.Components.ModalWindows;

/// <summary>
/// Class ChangeGroupModalWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class ChangeGroupModalWindow
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
    /// Gets or sets the change visible.
    /// </summary>
    /// <value>The change visible.</value>
    [Parameter]
    public EventCallback<bool> ChangeVisible { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ChangeGroupModalWindow" /> is visible.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    /// <summary>
    /// Gets or sets the selected curator.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedCuratorValue { get; set; }

    /// <summary>
    /// Gets or sets the selected curator.
    /// </summary>
    /// <value>The selected division.</value>
    private User? SelectedCurator { get; set; }

    /// <summary>
    /// The divisions
    /// </summary>
    private List<User>? _curators;

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
        var curators = JsonConvert.DeserializeObject<List<User>>(ret.Result.Items?.ToString() ?? string.Empty);

        if (curators != null) 
            _curators = curators.Where(i => i.Role?.Name == "Curator").ToList();

        if (_curators != null) 
            SelectedCurator = _curators.FirstOrDefault(i => i.Group?.Name == Group?.Name);

        if(SelectedCurator != null)
        {
            SelectedCuratorValue = SelectedCurator.Name;
        }
    }
    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine("e");
        ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// on modal OK button is click, submit form manually
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private async void HandleOk(MouseEventArgs e)
    {
        if (Group != null && SelectedCurator != null)
        {
            SelectedCurator.Group = Group;
            SelectedCurator.GroupId = Group.Id;

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