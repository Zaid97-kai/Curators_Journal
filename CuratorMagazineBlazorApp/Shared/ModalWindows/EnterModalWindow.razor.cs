using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace CuratorMagazineBlazorApp.Shared.ModalWindows;

/// <summary>
/// Class ModalWindowEnter.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class EnterModalWindow
{
    /// <summary>
    /// The model
    /// </summary>
    private User _model = new();

    /// <summary>
    /// Gets or sets the role callback.
    /// </summary>
    /// <value>The role callback.</value>
    [Parameter]
    public EventCallback<User> RoleCallback { get; set; }

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
    /// Called when [finish].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine($"Success: {JsonConvert.SerializeObject(_model)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed: {JsonConvert.SerializeObject(_model)}");
    }

    /// <summary>
    /// Authorizations this instance.
    /// </summary>
    public async void Authorization()
    {
        var users = await UserService?.PostAsync()!;
        var list = JsonConvert.DeserializeObject<List<User>>(users.Result.Items?.ToString() ?? string.Empty);

        await FindUser(list);

        //if (_model.Role?.Name == "Администратор")
        //{
        //    NavigationManager.NavigateTo($"admin", true);
        //}

        await RoleCallback.InvokeAsync(_model);
    }

    /// <summary>
    /// Finds the user.
    /// </summary>
    /// <param name="list">The list.</param>
    private async Task FindUser(List<User>? list)
    {
        if (list != null)
            foreach (var user in list.Where(user => user.Name == _model.Name && user.Password == _model.Password))
            {
                _model = user;
            }
    }
}