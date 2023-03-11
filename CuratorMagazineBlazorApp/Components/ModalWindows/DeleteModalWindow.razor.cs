using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using WebClient.Data.Services;
using Shared.Entities.Domains;

namespace WebClient.Components.ModalWindows;

/// <summary>
/// Class DeleteModalWindow.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="ComponentBase" />
public partial class DeleteModalWindow<T> : ComponentBase
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="DeleteModalWindow{T}"/> is visible.
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; }

    /// <summary>
    /// Gets or sets the object identifier.
    /// </summary>
    /// <value>The object identifier.</value>
    public int ObjectId { get; set; }

    /// <summary>
    /// Gets or sets the name of the object.
    /// </summary>
    /// <value>The name of the object.</value>
    public string? ObjectName { get; set; }

    /// <summary>
    /// Gets or sets the object.
    /// </summary>
    /// <value>The object.</value>
    [Parameter]
    public T? Object { get; set; }

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
    private UserService? UserService { get; set; }

    /// <summary>
    /// Gets or sets the division service.
    /// </summary>
    /// <value>The division service.</value>
    [Inject]
    private DivisionService? DivisionService { get; set; }

    /// <summary>
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    private GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the event service.
    /// </summary>
    /// <value>The event service.</value>
    [Inject]
    private EventService? EventService { get; set; }

    /// <summary>
    /// Gets or sets the parent service.
    /// </summary>
    /// <value>The parent service.</value>
    [Inject]
    private ParentService? ParentService { get; set; }

    /// <summary>
    /// Handles the ok.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private async void HandleOk(MouseEventArgs e)
    {
        if (Object?.GetType() == typeof(User))
        {
            await UserService?.DeleteAsync(ObjectId)!;
        }
        else if (Object?.GetType() == typeof(Division))
        {
            await DivisionService?.DeleteAsync(ObjectId)!;
        }
        else if (Object?.GetType() == typeof(Group))
        {
            await GroupService?.DeleteAsync(ObjectId)!;
        }
        else if (Object?.GetType() == typeof(Event))
        {
            await EventService?.DeleteAsync(ObjectId)!;
        }
        else
        {
            await ParentService?.DeleteAsync(ObjectId)!;
        }

        await ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private void HandleCancel(MouseEventArgs e)
    {
        ChangeVisible.InvokeAsync(false);
    }

    /// <summary>
    /// Method invoked when the component is ready to start, having received its
    /// initial parameters from its parent in the render tree.
    /// </summary>
    protected override void OnInitialized()
    {
        if (Object?.GetType() == typeof(User))
        {
            ObjectName = (Object as User)?.Name;
            ObjectId = ((Object as User)!).Id;

        }
        else if (Object?.GetType() == typeof(Division))
        {
            ObjectName = (Object as Division)?.Name;
            ObjectId = ((Object as Division)!).Id;
        }
        else if (Object?.GetType() == typeof(Group))
        {
            ObjectName = (Object as Group)?.Name;
            ObjectId = ((Object as Group)!).Id;
        }
        else if (Object?.GetType() == typeof(Event))
        {
            ObjectName = (Object as Event)?.Name;
            ObjectId = ((Object as Event)!).Id;
        }
        else
        {
            ObjectName = (Object as Parent)?.Name;
            ObjectId = ((Object as Parent)!).Id;
        }
    }
}