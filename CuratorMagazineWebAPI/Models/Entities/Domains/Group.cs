using System.Text.Json.Serialization;

namespace API.Models.Entities.Domains;

/// <summary>
/// Class Group.
/// </summary>
public class Group
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    [JsonIgnore]
    public virtual List<User>? Users { get; set; }
}