using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TM.Framework.Models
{
    public interface IRepository<TEntity> : IRepositoryWithTypedId<TEntity, Guid> { }

    /// <summary>
    /// Provides a standard interface for repository which are data-access mechanism agnostic.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks>The entity will not be actually persisted until calling <seealso cref="SaveAllChanges"/></remarks>
        void Add(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks>The entity will not be actually persisted until calling <seealso cref="SaveAllChanges"/></remarks>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks>The entity will not be actually persisted until calling <seealso cref="SaveAllChanges"/></remarks>
        bool Delete(TEntity entity);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] fetchSelectors);

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Queries the other.
        /// </summary>
        /// <typeparam name="TEntity1">The type of the entity1.</typeparam>
        /// <returns></returns>
        IQueryable<TEntity1> GetQueryOther<TEntity1>();

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate,
                        params Expression<Func<TEntity, object>>[] fetchSelectors);

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
                                  params Expression<Func<TEntity, object>>[] fetchSelectors);

        #region Orderable
        ///// <summary>
        ///// Finds the specified predicate.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="order">The order.</param>
        ///// <param name="fetchSelectors">The fetch selectors.</param>
        ///// <returns></returns>
        ///// <example>
        ///// Find(x =&gt; x.Active,
        /////   </example>
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
        //                            Action<IOrderable<TEntity>> order,
        //                            params Expression<Func<TEntity, object>>[] fetchSelectors);

        ///// <summary>
        ///// Finds the specified predicate.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="order">The order.</param>
        ///// <param name="pageNumber">The page number.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <param name="totalCount">The total count.</param>
        ///// <param name="fetchSelectors">The fetch selectors.</param>
        ///// <returns></returns>
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
        //                            Action<IOrderable<TEntity>> order,
        //                            int pageNumber,
        //                            int pageSize,
        //                            out int totalCount,
        //                            params Expression<Func<TEntity, object>>[] fetchSelectors); 
        #endregion

        /// <summary>
        /// Fetches the properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fetchSelector">The fetch selector.</param>
        void FetchProperties(TEntity entity, params Expression<Func<TEntity, object>>[] fetchSelector);

        /// <summary>
        /// Copies the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        void Copy(TEntity source, TEntity target);

        /// <summary>
        /// Counts number of entities that satisfied the predicate expression.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Saves all changes have made into persistence medium.
        /// </summary>
        void SaveAllChanges();

        /// <summary>
        /// Exists the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// Provides a standard interface for repository which are data-access mechanism agnostic.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentity">The type of the identity.</typeparam>
    public interface IRepositoryWithTypedId<TEntity, in TIdentity> : IBaseRepository<TEntity>
    {
        /// <summary>
        /// Gets the entity with eager loading the selected properties by the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        TEntity Get(TIdentity id, params Expression<Func<TEntity, object>>[] fetchSelectors);


        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByIds(IEnumerable<TIdentity> ids, params Expression<Func<TEntity, object>>[] fetchSelectors);

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool Delete(TIdentity id);

        /// <summary>
        /// Merges the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TEntity Merge(TEntity entity);
    }

}
