using Microsoft.EntityFrameworkCore;

namespace API.Models.Entities.Domains;

public class GroupEvent
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the group identifier.
    /// </summary>
    /// <value>The group identifier.</value>
    public int? GroupId { get; set; }

    /// <summary>
    /// Gets or sets the group.
    /// </summary>
    /// <value>The group.</value>
    public virtual Group? Group { get; set; }

    /// <summary>
    /// Gets or sets the event identifier.
    /// </summary>
    /// <value>The event identifier.</value>
    public int? EventId { get; set; }

    /// <summary>
    /// Gets or sets the division.
    /// </summary>
    /// <value>The event.</value>
    public virtual Event? Event { get; set; }
}
