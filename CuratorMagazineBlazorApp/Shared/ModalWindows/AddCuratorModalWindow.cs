using API.Models.Entities.Domains;
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
    /// Gets or sets the change visible.
    /// </summary>
    /// <value>The change visible.</value>
    [Parameter]
    public EventCallback<bool> ChangeVisible { get; set; }

    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedDivisionItem { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private Division? SelectedDivision { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedGroupItem { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private Group? SelectedGroup { get; set; }

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
    /// Gets or sets the role service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public RoleService? RoleService { get; set; }

    /// <summary>
    /// Gets or sets the role service.
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
    /// The divisions
    /// </summary>
    private List<Division>? _divisions; 

    /// <summary>
    /// The divisions
    /// </summary>
    private List<Group>? _groups;

    /// <summary>
    /// The roles
    /// </summary>
    private List<Role>? _roles;

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
        _groups = JsonConvert.DeserializeObject<List<Group>>(gret.Result.Items?.ToString() ?? string.Empty);

        var vret = await RoleService?.PostAsync()!;
        _roles = JsonConvert.DeserializeObject<List<Role>>(vret.Result.Items?.ToString() ?? string.Empty);
    }

    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine("e");
        ChangeVisible.InvokeAsync(false);
    }


    /// <summary>
    /// on modal OK button is click, submit form manually
    /// </summary>
    /// <param name="e"></param>
    private async void HandleOkAsync(MouseEventArgs e)
    {
        if (_curator != null)
        {
            _curator.DivisionId = SelectedDivision?.Id;
            _curator.GroupId = SelectedGroup?.Id;

            if (_roles != null)
            {
                var selectedRole = _roles.FirstOrDefault(i => i.Name == "Curator");

                _curator.RoleId = selectedRole?.Id;
            }

            await UserService?.CreateAsync(_curator)!;
        }

        await ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// Called when [selected item changed handler].
    /// </summary>
    /// <param name="value">The value.</param>
    private void OnSelectedDivisionItemChangedHandler(Division value)
    {
        SelectedDivision = value;
    }

    /// <summary>
    /// Called when [selected item changed handler].
    /// </summary>
    /// <param name="value">The value.</param>
    private void OnSelectedGroupItemChangedHandler(Group value)
    {
        SelectedGroup = value;
    }
}
