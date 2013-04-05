using System.Collections.Generic;
using System.Reflection;
using AutoMapper;

namespace TM.Framework.Mapping
{
    /// <summary>
    /// AutoMapper engine.
    /// </summary>
    public class AutoMapperEngine : IMappingEngine
    {
        #region IMappingEngine Members

        /// <summary>
        /// Maps source object to destination object
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Mapped object</returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

        #endregion
    }
}