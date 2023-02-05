using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using WebClient.Data.Services;

namespace WebClient.Shared.ModalWindows;

/// <summary>
/// Class AddStudentModalWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class AddStudentModalWindow
{
    /// <summary>
    /// Gets or sets the role callback.
    /// </summary>
    /// <value>The role callback.</value>
    [Parameter]
    public EventCallback<User> RoleCallback { get; set; }

    /// <summary>
    /// Gets or sets the add student.
    /// </summary>
    /// <value>The add student.</value>
    [Parameter]
    public EventCallback<User> AddStudent { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// The student
    /// </summary>
    private User _student = new User();

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success:{JsonSerializer.Serialize(_student)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed:{JsonSerializer.Serialize(_student)}");
    }
}