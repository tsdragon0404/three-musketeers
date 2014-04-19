using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Core.Data.NHibernate
{
    /// <summary>
    /// Provides a fully loaded data access component for any entity
    /// </summary>
    public abstract class BaseRepository
    {
        #region Constants and Fields

        #endregion Constants and Fields

        #region Constructors and Destructors

        #endregion Constructors and Destructors

        #region Properties

        /// <summary>
        /// Gets the current session.
        /// </summary>
        /// <value>The session.</value>
        public virtual ISession Session { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Provides a fully loaded data access component
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Constants and Fields

        #endregion Constants and Fields

        #region Constructors and Destructors

        #endregion Constructors and Destructors

        #region Properties

        /// <summary>
        /// Gets the current session.
        /// </summary>
        /// <value>The session.</value>
        public virtual ISession Session { get; set; }

        #endregion Properties

        #region IBaseRepository<TEntity>

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(TEntity entity)
        {
            Session.Save(entity);
        }

        /// <summary>
        /// Counts the number of entities by the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetQuery(predicate).Count();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual bool Delete(TEntity entity)
        {
            Session.Delete(entity);
            return true;
        }

        /// <summary>
        /// Fetches the property.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fetchSelector">The fetch selector.</param>
        public void FetchProperties(TEntity entity, params Expression<Func<TEntity, object>>[] fetchSelector)
        {
            if (entity != null && fetchSelector != null)
            {
                fetchSelector.ForEach(
                    selector =>
                    {
                        object propertyProxy = selector.Compile().Invoke(entity);
                        NHibernateUtil.Initialize(propertyProxy);
                    });
            }
        }

        /// <summary>
        /// Finds entities by the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            var entities = Fetches(GetQuery(predicate), fetchSelectors);
            return typeof(ISortableEntity).IsAssignableFrom(typeof(TEntity)) ? entities.OrderBy(e => ((ISortableEntity)e).SEQ).ToList() : entities.ToList();
        }

        /// <summary>
        /// Finds the one entity by the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public TEntity FindOne(
            Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            return Fetches(GetQuery(predicate), fetchSelectors).FirstOrDefault();
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            var entities = Fetches(Session.Query<TEntity>(), fetchSelectors);

            return typeof(ISortableEntity).IsAssignableFrom(typeof(TEntity)) ? entities.OrderBy(e => ((ISortableEntity)e).SEQ).ToList() : entities.ToList();
        }

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery()
        {
            return Session.Query<TEntity>();
        }

        /// <summary>
        /// Saves all changes explicitly.
        /// </summary>
        public void SaveAllChanges()
        {
            Session.Flush();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            Session.Update(entity);
        }

        /// <summary>
        /// Exists the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Session.Query<TEntity>().Any(predicate);
        }

        #endregion IBaseRepository<TEntity>

        #region Methods

        /// <summary>
        /// Fetcheses the specified query over.
        /// </summary>
        /// <param name="query">The query over.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        private static IQueryable<TEntity> Fetches(
            IQueryable<TEntity> query, Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            if (fetchSelectors != null && fetchSelectors.Length > 0)
            {
                fetchSelectors.ForEach(s => query = query.Fetch(s));
            }

            return query;
        }

        private IQueryable<TEntity> GetQuery(
            Expression<Func<TEntity, bool>> predicate)
        {
            var query = Session.Query<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        #endregion Methods
    }
}