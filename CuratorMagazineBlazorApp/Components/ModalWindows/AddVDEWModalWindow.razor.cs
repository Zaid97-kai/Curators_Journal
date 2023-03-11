using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Components.ModalWindows;

/// <summary>
/// Class ModalAddVDEWWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class AddVDEWModalWindow
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="AddVDEWModalWindow" /> is visible.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; }

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
    /// Gets or sets the division service.
    /// </summary>
    /// <value>The division service.</value>
    [Inject]
    public DivisionService? DivisionService { get; set; }

    /// <summary>
    /// Gets or sets the division service.
    /// </summary>
    /// <value>The division service.</value>
    [Inject]
    public RoleService? RoleService { get; set; }

    /// <summary>
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    /// <summary>
    /// The vdew
    /// </summary>
    private User? _vdew = new();

    /// <summary>
    /// The divisions
    /// </summary>
    private List<Division>? _divisions = new();

    /// <summary>
    /// The divisions
    /// </summary>
    private List<Role>? _roles = new();

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
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await DivisionService?.PostAsync()!;
        _divisions = JsonConvert.DeserializeObject<List<Division>>(ret.Result.Items?.ToString() ?? string.Empty);

        var vret = await RoleService?.PostAsync()!;
        _roles = JsonConvert.DeserializeObject<List<Role>>(vret.Result.Items?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success: {JsonConvert.SerializeObject(_vdew)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed: {JsonConvert.SerializeObject(_vdew)}");
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
    /// <returns>A Task representing the asynchronous operation.</returns>
    private async Task HandleOkAsync(MouseEventArgs e)
    {
        if (_vdew != null)
        {
            _vdew.DivisionId = SelectedDivision?.Id;

            if (_roles != null)
            {
                var selectedRole = _roles.FirstOrDefault(i => i.Name == "Deputy Director");

                _vdew.RoleId = selectedRole?.Id;
            }

            await UserService?.CreateAsync(_vdew)!;
        }
        
        await ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// Called when [selected item changed handler].
    /// </summary>
    /// <param name="value">The value.</param>
    private void OnSelectedItemChangedHandler(Division value)
    {
        SelectedDivision = value;
    }
}