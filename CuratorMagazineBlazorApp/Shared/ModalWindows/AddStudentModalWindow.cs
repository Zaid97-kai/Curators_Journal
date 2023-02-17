using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Shared.ModalWindows
{
    public partial class AddStudentModalWindow
    {
        private User? _student = new();


        /// <summary>
        /// Gets or sets the change visible.
        /// </summary>
        /// <value>The change visible.</value>
        [Parameter]
        public EventCallback<bool> ChangeVisible { get; set; }

        [Parameter]
        public bool Visible { get; set; }

        [Inject]
        private ParentService? ParentService { get; set; }

        /// <summary>
        /// Gets or sets the division service.
        /// </summary>
        /// <value>The user service.</value>
        [Inject]
        public DivisionService? DivisionService { get; set; }

        /// <summary>
        /// Gets or sets the group service.
        /// </summary>
        /// <value>The user service.</value>
        [Inject]
        public GroupService? GroupService { get; set; }

        /// <summary>
        /// Gets or sets the group service.
        /// </summary>
        /// <value>The user service.</value>
        [Inject]
        public UserService? UserService { get; set; }

        /// <summary>
        /// Gets or sets the group service.
        /// </summary>
        /// <value>The user service.</value>
        [Inject]
        public RoleService? RoleService { get; set; }

        /// <summary>
        /// Gets or sets the selected curator.
        /// </summary>
        /// <value>The selected division.</value>
        private string? SelectedMotherValue { get; set; }

        /// <summary>
        /// Gets or sets the selected curator.
        /// </summary>
        /// <value>The selected division.</value>
        private Parent? SelectedMother { get; set; }

        /// <summary>
        /// The divisions
        /// </summary>
        private List<Parent>? _parents;

        /// <summary>
        /// Gets or sets the selected curator.
        /// </summary>
        /// <value>The selected division.</value>
        private string? SelectedFatherValue { get; set; }

        /// <summary>
        /// Gets or sets the selected curator.
        /// </summary>
        /// <value>The selected division.</value>
        private Parent? SelectedFather { get; set; }

        /// <summary>
        /// Gets or sets the selected division.
        /// </summary>
        /// <value>The selected division.</value>
        private string? SelectedDivisionValue { get; set; }

        /// <summary>
        /// Gets or sets the selected division.
        /// </summary>
        /// <value>The selected division.</value>
        private Division? SelectedDivision { get; set; }

        /// <summary>
        /// Gets or sets the selected division.
        /// </summary>
        /// <value>The selected division.</value>
        private string? SelectedGroupValue { get; set; }

        /// <summary>
        /// Gets or sets the selected division.
        /// </summary>
        /// <value>The selected division.</value>
        private Group? SelectedGroup { get; set; }

        /// <summary>
        /// The divisions
        /// </summary>
        private List<Division>? _divisions;

        /// <summary>
        /// The divisions
        /// </summary>
        private List<Group>? _groups;

        /// <summary>
        /// The roles
        /// </summary>
        private List<Role>? _roles;

        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success: {JsonConvert.SerializeObject(_student)}");
        }

        /// <summary>
        /// Called when [finish failed].
        /// </summary>
        /// <param name="editContext">The edit context.</param>
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed: {JsonConvert.SerializeObject(_student)}");

        }

        /// <summary>
        /// On initialized as an asynchronous operation.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        protected override async Task OnInitializedAsync()
        {
            var ret = await ParentService?.PostAsync()!;
            _parents = JsonConvert.DeserializeObject<List<Parent>>(ret.Result.Items?.ToString() ?? string.Empty);

            var dret = await DivisionService?.PostAsync()!;
            _divisions = JsonConvert.DeserializeObject<List<Division>>(dret.Result.Items?.ToString() ?? string.Empty);

            var gret = await GroupService?.PostAsync()!;
            _groups = JsonConvert.DeserializeObject<List<Group>>(gret.Result.Items?.ToString() ?? string.Empty);

            var vret = await RoleService?.PostAsync()!;
            _roles = JsonConvert.DeserializeObject<List<Role>>(vret.Result.Items?.ToString() ?? string.Empty);
        }

        /// <summary>
        /// on modal OK button is click, submit form manually
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private async void HandleOkAsync(MouseEventArgs e)
        {
            if (_student != null)
            {
                _student.DivisionId = SelectedDivision?.Id;
                _student.GroupId = SelectedGroup?.Id;
                _student.FatherId = SelectedFather?.Id;
                _student.MotherId = SelectedMother?.Id;
                _student.Password = "0";
                if (_roles != null)
                {
                    var selectedRole = _roles.FirstOrDefault(i => i.Name == "Student");

                    _student.RoleId = selectedRole?.Id;
                }

                await UserService?.CreateAsync(_student)!;
            }

            await ChangeVisible.InvokeAsync(false);
        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine("e");
            ChangeVisible.InvokeAsync(false);
        }

        /// <summary>
        /// Called when [selected item changed handler].
        /// </summary>
        /// <param name="value">The value.</param>
        private void OnSelectedMotherItemChangedHandler(Parent value)
        {
            SelectedMother = value;
        }

        /// <summary>
        /// Called when [selected item changed handler].
        /// </summary>
        /// <param name="value">The value.</param>
        private void OnSelectedFatherItemChangedHandler(Parent value)
        {
            SelectedFather = value;
        }

        /// <summary>
        /// Called when [selected item changed handler].
        /// </summary>
        /// <param name="value">The value.</param>
        private void OnSelectedDivisionItemChangedHandler(Division value)
        {
            SelectedDivision = value;
        }

        /// <summary>
        /// Called when [selected item changed handler].
        /// </summary>
        /// <param name="value">The value.</param>
        private void OnSelectedGroupItemChangedHandler(Group value)
        {
            SelectedGroup = value;
        }
    }
}
