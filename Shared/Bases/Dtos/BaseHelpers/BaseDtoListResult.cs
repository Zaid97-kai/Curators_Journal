namespace Shared.Bases.Dtos.BaseHelpers;

/// <summary>
/// Class BaseDtoListResult.
/// </summary>
public class BaseDtoListResult
{
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    /// <value>The items.</value>
    public object? Items { get; set; }

    /// <summary>
    /// Gets or sets the page count.
    /// </summary>
    /// <value>The page count.</value>
    public int PageCount { get; set; }
}