using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Shared.ModalWindows;

/// <summary>
/// Class AddCuratorModalWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class AddCuratorModalWindow
{
    /// <summary>
    /// The curator
    /// </summary>
    private User _curator = new();

    /// <summary>
    /// Gets or sets the role callback.
    /// </summary>
    /// <value>The role callback.</value>
    [Parameter]
    public EventCallback<User> RoleCallback { get; set; }

    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedDivision { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedGroup { get; set; }

    /// <summary>
    /// Gets or sets the division service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public DivisionService? DivisionService { get; set; }

    /// <summary>
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    /// <summary>
    /// The divisions
    /// </summary>
    private List<Division>? _divisions; 

    /// <summary>
    /// The divisions
    /// </summary>
    private List<Group>? _groups;

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success: {JsonConvert.SerializeObject(_curator)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed: {JsonConvert.SerializeObject(_curator)}");

    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await DivisionService?.PostAsync()!;
        _divisions = JsonConvert.DeserializeObject<List<Division>>(ret.Result.Items?.ToString() ?? string.Empty);

        var gret = await GroupService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(ret.Result.Items?.ToString() ?? string.Empty);
    }

    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine("e");
        Visible = false;
    }


    /// <summary>
    /// on modal OK button is click, submit form manually
    /// </summary>
    /// <param name="e"></param>
    private void HandleOk(MouseEventArgs e)
    {
        Visible = false;
    }
}
