using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;

namespace CuratorMagazineBlazorApp.Shared.ModalWindows;

/// <summary>
/// Class ModalChangeVDEWWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class ChangeVDEWModalWindow
{
    /// <summary>
    /// Gets or sets the vdew.
    /// </summary>
    /// <value>The vdew.</value>
    [Parameter]
    public User? VDEW { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ChangeVDEWModalWindow" /> is visible.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Gets or sets the division service.
    /// </summary>
    /// <value>The division service.</value>
    [Inject]
    public DivisionService? DivisionService { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// The divisions
    /// </summary>
    private List<Division>? _divisions = new();

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private string? SelectedValue { get; set; }

    /// <summary>
    /// Gets or sets the selected division.
    /// </summary>
    /// <value>The selected division.</value>
    private Division? SelectedDivision { get; set; }

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success: {JsonConvert.SerializeObject(VDEW)}");
        
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed: {JsonConvert.SerializeObject(VDEW)}");

    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await DivisionService?.PostAsync()!;
        _divisions = JsonConvert.DeserializeObject<List<Division>>(ret.Result.Items?.ToString() ?? string.Empty);

        SelectedValue = VDEW?.Division?.Name;
        SelectedDivision = VDEW?.Division;
    }
    
    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine("e");
        Visible = false;
    }

    /// <summary>
    /// on modal OK button is click, submit form manually
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private async void HandleOk(MouseEventArgs e)
    {
        if (VDEW != null)
        {
            VDEW.Division = SelectedDivision;
            VDEW.DivisionId = SelectedDivision?.Id;

            await UserService?.PutAsync(VDEW)!;
        }

        Visible = false;
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