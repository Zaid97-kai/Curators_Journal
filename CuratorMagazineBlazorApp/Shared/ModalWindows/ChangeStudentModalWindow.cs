using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using WebClient.Data.Services;
using Group = API.Models.Entities.Domains.Group;

namespace WebClient.Shared.ModalWindows
{
    public partial class ChangeStudentModalWindow
    {
        [Parameter]
        public User? Student { get; set; }

        /// <summary>
        /// Gets or sets the change visible.
        /// </summary>
        /// <value>The change visible.</value>
        [Parameter]
        public EventCallback<bool> ChangeVisible { get; set; }

        [Parameter]
        public bool Visible { get; set; }

        [Inject]
        private ParentService ParentService { get; set; }

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


        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success: {JsonConvert.SerializeObject(Student)}");
        }

        /// <summary>
        /// Called when [finish failed].
        /// </summary>
        /// <param name="editContext">The edit context.</param>
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed: {JsonConvert.SerializeObject(Student)}");

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

            if(_parents != null)
            {
                SelectedFather = _parents.FirstOrDefault(i => i.Id == Student.FatherId);
                SelectedMother = _parents.FirstOrDefault(i => i.Id == Student.MotherId);
            }
            
            if(Student != null && Student.DivisionId != null)
            {
                SelectedDivisionValue = Student?.Division?.Name;
                SelectedDivision = Student?.Division;
            }

            if(Student != null && Student.GroupId != null)
            {
                SelectedGroupValue = Student?.Group?.Name;
                SelectedGroup = Student?.Group;
            }

            if (SelectedFather != null)
            {
                SelectedMotherValue = SelectedMother.Name;
            }
            if (SelectedMother != null)
            {
                SelectedFatherValue = SelectedFather.Name;
            }

        }

        /// <summary>
        /// on modal OK button is click, submit form manually
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private async void HandleOkAsync(MouseEventArgs e)
        {
            if (Student != null)
            {
                Student.Division = SelectedDivision;
                Student.DivisionId = SelectedDivision?.Id;

                Student.Group = SelectedGroup;
                Student.GroupId = SelectedGroup?.Id;

                Student.Father = SelectedFather;
                Student.FatherId = SelectedFather.Id;

                Student.Mother = SelectedMother;
                Student.MotherId = SelectedMother.Id;

                await UserService?.PutAsync(Student)!;
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
