using System.Collections.Generic;
using System.Reflection;

namespace TM.Framework.Mapping
{
    /// <summary>
    /// An interface of mapping class.
    /// </summary>
    public interface IMappingEngine
    {
        /// <summary>
        /// Maps source object to destination object
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Mapped object</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}