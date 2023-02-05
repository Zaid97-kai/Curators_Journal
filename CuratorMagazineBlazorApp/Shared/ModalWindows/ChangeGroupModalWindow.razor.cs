using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;

namespace CuratorMagazineBlazorApp.Shared.ModalWindows
{
    public partial class ChangeGroupModalWindow
    {
        [Parameter]
        public Group? Group { get; set; }

        [Parameter]
        public User? CurrentUser { get; set; }


        /// <summary>
        /// Gets or sets the role callback.
        /// </summary>
        /// <value>The role callback.</value>
        [Parameter]
        public EventCallback<User> RoleCallback { get; set; }

        [Parameter]
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the selected curator.
        /// </summary>
        /// <value>The selected division.</value>
        private string? SelectedCuratorValue { get; set; }

        /// <summary>
        /// Gets or sets the selected curator.
        /// </summary>
        /// <value>The selected division.</value>
        private User? SelectedCurator { get; set; }

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
        /// The divisions
        /// </summary>
        private List<User>? _curators;

        /// <summary>
        /// Called when [finish].
        /// </summary>
        /// <param name="editContext">The edit context.</param>
        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success: {JsonConvert.SerializeObject(Group)}");
        }

        /// <summary>
        /// Called when [finish failed].
        /// </summary>
        /// <param name="editContext">The edit context.</param>
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed: {JsonConvert.SerializeObject(Group)}");

        }

        /// <summary>
        /// On initialized as an asynchronous operation.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        protected override async Task OnInitializedAsync()
        {
            var ret = await UserService?.PostAsync()!;
            var curarots = JsonConvert.DeserializeObject<List<User>>(ret.Result.Items?.ToString() ?? string.Empty);
            _curators = curarots.Where(i => i.Role.Name == "Curator").ToList();

            SelectedCurator = _curators.Where(i => i.Group.Name == Group.Name).FirstOrDefault();

            if(SelectedCurator != null)
            {
                SelectedCuratorValue = SelectedCurator.Name;
            }
        }
        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine("e");
            Visible = false;
        }


        /// <summary>
        /// on modal OK button is click, submit form manually
        /// </summary>
        /// <param name="e"></param>
        private async void HandleOk(MouseEventArgs e)
        {
            if (Group != null && SelectedCurator != null)
            {
                SelectedCurator.Group = Group;
                SelectedCurator.GroupId = Group.Id;

                await UserService?.PutAsync(SelectedCurator)!;
            }

            Visible = false;
        }

        /// <summary>
        /// Called when [selected item changed handler].
        /// </summary>
        /// <param name="value">The value.</param>
        private void OnSelectedCuratorItemChangedHandler(User value)
        {
            SelectedCurator = value;
        }
    }
}
