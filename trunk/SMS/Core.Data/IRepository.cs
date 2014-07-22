using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Data
{
    /// <summary>
    /// Provides a standard interface for repository which are data-access mechanism agnostic.
    /// Since nearly all of the domain objects you create will have a type of <see cref="Guid"/> Id, this
    /// base repository leverages this assumption.  If you want an entity with a type
    /// other than <see cref="Guid"/>, such as <see cref="string"/>, then use <see cref="IRepositoryWithTypedId{TEntity, TIdentity}"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> : IRepositoryWithTypedId<TEntity, long> { }

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
        IQueryable<TEntity> GetQuery();

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

        /// <summary>
        /// Finds entities by text and AllowSearchAttribute.
        /// </summary>
        /// <param name="textSearch">The text to search.</param>
        /// <param name="predicate">The predicate to search.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindByString(string textSearch, Expression<Func<TEntity, bool>> predicate,
                                          params Expression<Func<TEntity, object>>[] fetchSelectors);
        
        /// <summary>
        /// Fetches the properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fetchSelector">The fetch selector.</param>
        void FetchProperties(TEntity entity, params Expression<Func<TEntity, object>>[] fetchSelector);

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

        /// <summary>
        /// Execute the given stored procedure
        /// </summary>
        /// <param name="spName">The stored procedure name</param>
        /// <param name="parameters"> </param>
        object ExecuteStoredProcedure(string spName, Dictionary<string, string> parameters);
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
        IEnumerable<TEntity> GetByIDs(IEnumerable<TIdentity> ids, params Expression<Func<TEntity, object>>[] fetchSelectors);

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