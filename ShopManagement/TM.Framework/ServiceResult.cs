using System.Collections.Generic;

namespace TM.Framework
{
    /// <summary>
    /// The DataContract class contains validation result
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IList<InvalidDataError> Errors { get; set; }
    }

    /// <summary>
    /// The DataContract class contains validation result and model data
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class ServiceResult<TModel> : ServiceResult
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public TModel Data { get; set; }
    }

}