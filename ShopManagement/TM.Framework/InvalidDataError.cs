namespace TM.Framework
{
    /// <summary>
    /// Contain validation error information
    /// </summary>
    public class InvalidDataError
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the property data.
        /// </summary>
        /// <value>
        /// The property data.
        /// </value>
        public object PropertyData { get; set; }

        /// <summary>
        /// Gets or sets the type of the error.
        /// </summary>
        /// <value>
        /// The type of the error.
        /// </value>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// Gets or sets the message ID.
        /// </summary>
        /// <value>
        /// The message ID.
        /// </value>
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the Message Content.
        /// </summary>
        /// <value>
        /// The message content.
        /// </value>
        public string MessageContent { get; set; }

        /// <summary>
        /// Gets or sets the Message Caption.
        /// </summary>
        /// <value>
        /// The message caption.
        /// </value>
        public string MessageCaption { get; set; }

        /// <summary>
        /// Gets or sets the Message Type.
        /// </summary>
        /// <value>
        /// The message type.
        /// </value>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the Message Type Name.
        /// </summary>
        /// <value>
        /// The message type name.
        /// </value>
        public string MessageTypeName { get; set; }
    }

    public enum ErrorType
    {
        InvalidData = 0,
        InvalidBusinessRule = 1
    }
}
