namespace CuratorMagazineBlazorApp.Data.Interfaces;

/// <summary>
/// Interface IMetadataMessage
/// Extends the <see cref="CuratorMagazineBlazorApp.Data.Interfaces.IHaveDataObject" />
/// </summary>
/// <seealso cref="CuratorMagazineBlazorApp.Data.Interfaces.IHaveDataObject" />
public interface IMetadataMessage : IHaveDataObject
{
    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <value>The message.</value>
    string Message { get; }

    /// <summary>
    /// Gets the data object.
    /// </summary>
    /// <value>The data object.</value>
    object DataObject { get; }
}