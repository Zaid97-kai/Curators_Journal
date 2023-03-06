using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace WebClient.Shared.ModalWindows
{
    public partial class ShowEventModalWindow
    {
        [Parameter]
        public Event? Event { get; set; }

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
            Console.WriteLine($"Success: {JsonConvert.SerializeObject(Event)}");
        }

        /// <summary>
        /// Called when [finish failed].
        /// </summary>
        /// <param name="editContext">The edit context.</param>
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed: {JsonConvert.SerializeObject(Event)}");

        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine("e");
            ChangeVisible.InvokeAsync(false);
        }
    }
}
