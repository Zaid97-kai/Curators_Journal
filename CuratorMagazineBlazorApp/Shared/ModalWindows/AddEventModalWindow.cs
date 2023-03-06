using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace WebClient.Shared.ModalWindows
{
    public partial class AddEventModalWindow
    {

        private Event? _event = new();

        /// <summary>
        /// Gets or sets the change visible.
        /// </summary>
        /// <value>The change visible.</value>
        [Parameter]
        public EventCallback<bool> ChangeVisible { get; set; }

        [Parameter]
        public bool Visible { get; set; }

        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success: {JsonConvert.SerializeObject(_event)}");
        }

        /// <summary>
        /// Called when [finish failed].
        /// </summary>
        /// <param name="editContext">The edit context.</param>
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed: {JsonConvert.SerializeObject(_event)}");

        }

        /// <summary>
        /// on modal OK button is click, submit form manually
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private async void HandleOk(MouseEventArgs e)
        {

            await ChangeVisible.InvokeAsync(false);
        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine("e");
            ChangeVisible.InvokeAsync(false);
        }
    }
}
