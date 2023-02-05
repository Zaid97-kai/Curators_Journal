using System.Text.Json.Serialization;

namespace API.Models.Entities.Domains;

/// <summary>
/// Class Parent.
/// </summary>
public class Parent
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
    /// Gets or sets the name of the work.
    /// </summary>
    /// <value>The name of the work.</value>
    public string WorkName { get; set; }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    /// <value>The phone.</value>
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the mother childrens.
    /// </summary>
    /// <value>The mother childrens.</value>
    [JsonIgnore]
    public virtual List<User>? MotherChildrens { get; set; }

    /// <summary>
    /// Gets or sets the father childrens.
    /// </summary>
    /// <value>The father childrens.</value>
    [JsonIgnore]
    public virtual List<User>? FatherChildrens { get; set; }
}