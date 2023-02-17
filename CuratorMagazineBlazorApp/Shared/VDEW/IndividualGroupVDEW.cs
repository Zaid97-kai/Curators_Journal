using API.Models.Entities.Domains;
using WebClient.Data.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace WebClient.Shared.VDEW
{
    public partial class IndividualGroupVDEW
    {
        [Parameter]
        public Group? Group { get; set; }

        [Inject]
        public GroupService? GroupService { get; set; }

        [Inject]
        public UserService? UserService { get; set; }

        public User? user = new();

        private bool IsVisibleModalChangeGroupWindow { get; set; }

        private bool IsVisibleDeleteModalWindow { get; set; }

        public void ShowModalChangeGroupWindow()
        {
            IsVisibleModalChangeGroupWindow = !IsVisibleModalChangeGroupWindow;
        }

        public void ShowModalChangeGroupWindoParam(bool value)
        {
            IsVisibleModalChangeGroupWindow = value;
        }

        public void ShowDeleteModalWindow()
        {
            IsVisibleDeleteModalWindow = !IsVisibleDeleteModalWindow;
        }

        public void DeleteModalWindowParam(bool value)
        {
            IsVisibleDeleteModalWindow = value;
        }

        protected override async Task OnInitializedAsync()
        {
            var user1 = GroupService?.GetGroupCuratorAsync(Group!.Id).Result.Result;
            user = user1;
        }
    }
}
