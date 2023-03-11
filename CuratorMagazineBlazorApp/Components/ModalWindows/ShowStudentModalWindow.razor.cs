using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using Shared.Entities.Domains;

namespace WebClient.Components.ModalWindows;

/// <summary>
/// Class ShowStudentModalWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class ShowStudentModalWindow
{
    /// <summary>
    /// Gets or sets the student.
    /// </summary>
    /// <value>The student.</value>
    [Parameter]
    public User? Student { get; set; }

    /// <summary>
    /// Gets or sets the change visible.
    /// </summary>
    /// <value>The change visible.</value>
    [Parameter]
    public EventCallback<bool> ChangeVisible { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ShowStudentModalWindow"/> is visible.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success: {JsonConvert.SerializeObject(Student)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed: {JsonConvert.SerializeObject(Student)}");

    }

    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine("e");
        ChangeVisible.InvokeAsync(false);
    }
       
}