using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Shared.Entities.Domains;
using WebClient.Data.Services;

namespace WebClient.Components.StatsCollect;

/// <summary>
/// Class StatsCollectionPage.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class StatsCollectionPage
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
    /// Gets or sets the role service.
    /// </summary>
    /// <value>The role service.</value>
    [Inject]
    public RoleService? RoleService { get; set; }

    /// <summary>
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    public GroupService? GroupService { get; set; }

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    public UserService? UserService { get; set; }

    /// <summary>
    /// Gets or sets the group event service.
    /// </summary>
    /// <value>The group event service.</value>
    [Inject]
    public GroupEventService? GroupEventService { get; set; }

    /// <summary>
    /// Gets or sets the event service.
    /// </summary>
    /// <value>The event service.</value>
    [Inject]
    public EventService? EventService { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible add student modal window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible add student modal window; otherwise, <c>false</c>.</value>
    private bool IsVisibleAddStudentModalWindow { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible add event modal window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible add event modal window; otherwise, <c>false</c>.</value>
    private bool IsVisibleAddEventModalWindow { get; set; }

    /// <summary>
    /// The groups
    /// </summary>
    private List<Group>? _groups = new();

    /// <summary>
    /// The roles
    /// </summary>
    private List<Role>? _roles = new();

    /// <summary>
    /// The users
    /// </summary>
    private List<User>? _users = new();

    /// <summary>
    /// The events
    /// </summary>
    private List<Event>? _events = new();

    /// <summary>
    /// The group events
    /// </summary>
    private List<GroupEvent>? _groupEvents = new();

    /// <summary>
    /// The role
    /// </summary>
    private Role? _role = new();

    /// <summary>
    /// Shows the modal add student window.
    /// </summary>
    public void ShowModalAddStudentWindow()
    {
        IsVisibleAddStudentModalWindow = !IsVisibleAddStudentModalWindow;
    }

    /// <summary>
    /// Modals the add student window parameter.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    public void ModalAddStudentWindowParam(bool value)
    {
        IsVisibleAddStudentModalWindow = value;
    }

    /// <summary>
    /// Shows the modal add event window.
    /// </summary>
    public void ShowModalAddEventWindow()
    {
        IsVisibleAddEventModalWindow = !IsVisibleAddEventModalWindow;
    }

    /// <summary>
    /// Modals the add event window parameter.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    public void ModalAddEventWindowParam(bool value)
    {
        IsVisibleAddEventModalWindow = value;
    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var group = await GroupService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<Group>>(group.Result.Items?.ToString() ?? string.Empty);

        var users = await UserService?.PostAsync()!;
        _users = JsonConvert.DeserializeObject<List<User>>(users.Result.Items?.ToString() ?? string.Empty);

        var roles = await RoleService?.PostAsync()!;
        _roles = JsonConvert.DeserializeObject<List<Role>>(roles.Result.Items?.ToString() ?? string.Empty);

        var events = await EventService?.PostAsync()!;
        _events = JsonConvert.DeserializeObject<List<Event>>(events.Result.Items?.ToString() ?? string.Empty);

        //var groupEvents = await GroupEventService?.PostAsync()!;
        //_groupEvents = JsonConvert.DeserializeObject<List<GroupEvent>>(groupEvents.Result.Items?.ToString() ?? string.Empty);

        _role = _roles.FirstOrDefault(i => i.Name == "Curator");

        Group = _groups.FirstOrDefault(i => i.Id == 7);
        CurrentUser = _users.FirstOrDefault(i => i.GroupId == 7);

        //_groupEvents = _groupEvents.Where(i => i.GroupId == Group.Id).ToList();

        //var displayEvents = new List<Event>();
        //foreach(var groupEvent in _groupEvents)
        //{
        //    foreach(var @event in _events)
        //    {
        //        if (groupEvent.Id == @event.Id)
        //        {
        //            displayEvents.Add(@event);
        //        }
        //    }
        //}

        //if(displayEvents != null)
        //{
        //    _events = displayEvents;
        //}

        Group!.Users ??= new List<User>();

        if (Group.Users.Count == 0)
        {
            foreach (var item in _users)
            {
                Group.Users.Add(item);
            }
        }
    }
}