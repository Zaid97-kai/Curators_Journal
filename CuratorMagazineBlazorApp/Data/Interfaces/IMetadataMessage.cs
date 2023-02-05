namespace WebClient.Data.Interfaces;

/// <summary>
/// Interface IMetadataMessage
/// Extends the <see cref="IHaveDataObject" />
/// </summary>
/// <seealso cref="IHaveDataObject" />
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