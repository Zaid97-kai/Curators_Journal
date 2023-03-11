using System.Text.Json.Serialization;

namespace Shared.Entities.Domains
{
    public class Event
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
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The name.</value>
        public string? Comment { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The name.</value>
        public DateTime? DateEvent { get; set; }

        /// <summary>
        /// Gets or sets the profile photo.
        /// </summary>
        /// <value>The profile photo.</value>
        public byte[]? EventPhoto { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        [JsonIgnore]
        public virtual List<User>? Users { get; set; }
    }
}
