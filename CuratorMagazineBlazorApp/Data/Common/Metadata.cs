using CuratorMagazineBlazorApp.Data.Interfaces;

namespace CuratorMagazineBlazorApp.Data.Common;

/// <summary>
/// Enum MetadataType
/// </summary>
public enum MetadataType
{
    /// <summary>
    /// The information
    /// </summary>
    Info,
    /// <summary>
    /// The success
    /// </summary>
    Success,
    /// <summary>
    /// The warning
    /// </summary>
    Warning,
    /// <summary>
    /// The error
    /// </summary>
    Error,
}

/// <summary>
/// Class Metadata.
/// Implements the <see cref="IMetadataMessage" />
/// Implements the <see cref="IHaveDataObject" />
/// </summary>
/// <seealso cref="IMetadataMessage" />
/// <seealso cref="IHaveDataObject" />
[Serializable]
public class Metadata : IMetadataMessage, IHaveDataObject
{
    /// <summary>
    /// The source
    /// </summary>
    private readonly OperationResult _source;

    /// <summary>
    /// Initializes a new instance of the <see cref="Metadata"/> class.
    /// </summary>
    public Metadata() => Type = MetadataType.Info;

    /// <summary>
    /// Initializes a new instance of the <see cref="Metadata"/> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="message">The message.</param>
    public Metadata(OperationResult source, string message)
        : this()
    {
        _source = source;
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Metadata"/> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="message">The message.</param>
    /// <param name="type">The type.</param>
    public Metadata(OperationResult source, string message, MetadataType type = MetadataType.Info)
    {
        Type = type;
        _source = source;
        Message = message;
    }

    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <value>The message.</value>
    public string Message { get; }

    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>The type.</value>
    public MetadataType Type { get; }

    /// <summary>
    /// Gets the data object.
    /// </summary>
    /// <value>The data object.</value>
    public object DataObject { get; private set; }

    /// <summary>
    /// Adds the data.
    /// </summary>
    /// <param name="data">The data.</param>
    public void AddData(object data)
    {
        if (data is Exception exception && _source.Metadata == null)
            _source.Metadata = new Metadata(_source, exception.Message);
        else
            _source.Metadata.DataObject = data;
    }
}