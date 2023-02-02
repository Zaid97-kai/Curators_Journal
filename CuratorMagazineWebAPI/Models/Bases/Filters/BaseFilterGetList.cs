// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-21-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-21-2022
// ***********************************************************************
// <copyright file="BaseFilterGetList.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CuratorMagazineWebAPI.Models.Bases.Filters;

/// <summary>
/// Class BaseFilterGetList.
/// </summary>
public class BaseFilterGetList
{
    /// <summary>
    /// The page
    /// </summary>
    private int? _page;

    /// <summary>
    /// Gets or sets the query.
    /// </summary>
    /// <value>The query.</value>
    public string query { get; set; }

    /// <summary>
    /// Gets or sets the page.
    /// </summary>
    /// <value>The page.</value>
    public int page
    {
        get => _page ?? 1;
        set => _page = value;
    }

    public int? groupId { get; set; }
}