using AntDesign.Core.Helpers.MemberPath;
using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineBlazorApp.Models.States;
using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;


namespace CuratorMagazineBlazorApp.Shared.StatsCollect
{
    public partial class StatsCollect
    {
        [Parameter]
        public User? CurrentUser { get; set; }

        [Inject]
        public GroupService? GroupService { get; set; }

        [Parameter]
        public StateRoleNavBar? StateRoleNavBar { get; set; } = new();

        [Parameter]
        public EventCallback<StateRoleNavBar> StateRoleNavBarCallback { get; set; }

        private List<Group>? _groups;

        protected override async Task OnInitializedAsync()
        {
            _groups = new List<Group>();
            var groups = await GroupService.PostAsync();
            _groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);
        }

        public void ChangeOnWorkWithVDEWStateRoleNavBar()
        {
            StateRoleNavBar = new StateRoleNavBar() { RoleName = "StatsCollectionPage" };
            StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
        }
    }
}
