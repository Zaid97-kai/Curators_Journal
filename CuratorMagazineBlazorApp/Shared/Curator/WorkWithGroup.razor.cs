using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CuratorMagazineBlazorApp.Shared.Curator
{
    public partial class WorkWithGroup
    {
        [Parameter]
        public User? CurrentUser { get; set; }

        [Inject]
        public UserService? UserService { get; set; }

        private List<Group>? _groups = new ();

        void DeleteGroup(User user)
        {

        }

        void AddGroup(User user)
        {

        }

        async Task GetGroups()
        {
            _groups = new List<Group>();
            var groups = await UserService.PostAsync();
            _groups = JsonConvert.DeserializeObject<List<Group>>(groups.Result.Items?.ToString() ?? string.Empty);
        }
    }
}
