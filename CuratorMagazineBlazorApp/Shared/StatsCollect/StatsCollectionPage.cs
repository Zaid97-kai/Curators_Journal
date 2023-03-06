using API.Models.Entities.Domains;
using WebClient.Models.States;
using WebClient.Data.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace WebClient.Shared.StatsCollect
{
    public partial class StatsCollectionPage
    {
        [Parameter]
        public Group? Group { get; set; }

        [Parameter]
        public User? CurrentUser { get; set; }

        [Inject]
        public RoleService? RoleService { get; set; }

        [Inject]
        public GroupService? GroupService { get; set; }

        [Inject]
        public UserService? UserService { get; set; }

        [Inject]
        public GroupEventService? GroupEventService { get; set; }

        [Inject]
        public EventService? EventService { get; set; }

        private bool IsVisibleAddStudentModalWindow { get; set; }

        private bool IsVisibleAddEventModalWindow { get; set; }

        private List<Group>? _groups = new();

        private List<Role>? _roles = new();

        private List<User>? _users = new();

        private List<Event>? _events = new();

        private List<GroupEvent>? _groupEvents = new();

        private Role _role;

        public void ShowModalAddStudentWindow()
        {
            IsVisibleAddStudentModalWindow = !IsVisibleAddStudentModalWindow;
        }

        public void ModalAddStudentWindowParam(bool value)
        {
            IsVisibleAddStudentModalWindow = value;
        }

        public void ShowModalAddEventWindow()
        {
            IsVisibleAddEventModalWindow = !IsVisibleAddEventModalWindow;
        }

        public void ModalAddEventWindowParam(bool value)
        {
            IsVisibleAddEventModalWindow = value;
        }

        public void ShowImportWindow()
        {
            

        }


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

            if (Group.Users == null)
            {
                Group.Users = new();
            }

            if (Group.Users.Count == 0)
            {
                foreach (var item in _users)
                {
                    Group.Users.Add(item);
                }
            }


        }
    }
}
