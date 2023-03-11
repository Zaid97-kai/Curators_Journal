using API.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;

namespace WebClient.Components.DEW;

/// <summary>
/// Class IndividualVDEW.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class IndividualVDEW
{

    /// <summary>
    /// Gets or sets the vdew.
    /// </summary>
    /// <value>The vdew.</value>
    [Parameter]
    public User? VDEW { get; set; }

    /// <summary>
    /// Gets or sets the delete vdew.
    /// </summary>
    /// <value>The delete vdew.</value>
    [Parameter]
    public EventCallback<User> DeleteVDEW { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible modal change vdew window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible modal change vdew window; otherwise, <c>false</c>.</value>
    private bool IsVisibleModalChangeVdewWindow { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible delete modal window.
    /// </summary>
    /// <value><c>true</c> if this instance is visible delete modal window; otherwise, <c>false</c>.</value>
    private bool IsVisibleDeleteModalWindow { get; set; }

    /// <summary>
    /// Shows the modal change vdew window.
    /// </summary>
    public void ShowModalChangeVdewWindow()
    {
        IsVisibleModalChangeVdewWindow = !IsVisibleModalChangeVdewWindow;
    }

    /// <summary>
    /// Modals the change vdew window parameter.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    public void ModalChangeVdewWindowParam(bool value)
    {
        IsVisibleModalChangeVdewWindow = value;
    }

    /// <summary>
    /// Shows the delete modal window.
    /// </summary>
    public void ShowDeleteModalWindow()
    {
        IsVisibleDeleteModalWindow = !IsVisibleDeleteModalWindow;
    }

    /// <summary>
    /// Deletes the modal window parameter.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    public void DeleteModalWindowParam(bool value)
    {
        IsVisibleDeleteModalWindow = value;
    }
}