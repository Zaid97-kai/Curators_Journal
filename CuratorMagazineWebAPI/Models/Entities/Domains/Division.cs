// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-19-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="Division.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.Json.Serialization;

namespace CuratorMagazineWebAPI.Models.Entities.Domains;

/// <summary>
/// Class Division.
/// </summary>
public class Division
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