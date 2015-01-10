﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Core.Common;
using Core.Common.CustomAttributes;
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
        protected ISession Session { get { return UnitOfWork.Current.Session; } }

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
        protected ISession Session { get { return UnitOfWork.Current.Session; } }

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
                        var propertyProxy = selector.Compile().Invoke(entity);
                        NHibernateUtil.Initialize(propertyProxy);
                    });
            }
        }

        /// <summary>
        /// Finds entities by the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="forceReload">Force to reload from db.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate, bool forceReload = false, params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            if(forceReload)
                Session.Evict(typeof(TEntity));
            var entities = Fetches(GetQuery(predicate), fetchSelectors);
            return typeof(ISortableEntity).IsAssignableFrom(typeof(TEntity)) ? entities.OrderBy(e => ((ISortableEntity)e).SEQ).ToList() : entities.ToList();
        }

        /// <summary>
        /// Finds entities by text and AllowSearchAttribute.
        /// </summary>
        /// <param name="textSearch">The text to search.</param>
        /// <param name="predicate">The predicate to search.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindByString(string textSearch, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            var entities = Fetches(GetQuery(predicate), fetchSelectors);

            if (textSearch.IsNullOrEmpty())
                return typeof(ISortableEntity).IsAssignableFrom(typeof(TEntity)) ? entities.OrderBy(e => ((ISortableEntity)e).SEQ).ToList() : entities.ToList();

            var filteredEntities = entities.ToList().Where(x => SearchByAttribute(x, textSearch)).ToList();

            return typeof(ISortableEntity).IsAssignableFrom(typeof(TEntity)) ? filteredEntities.OrderBy(e => ((ISortableEntity)e).SEQ).ToList() : filteredEntities.ToList();
        }

        private bool SearchByAttribute(object entity, object searchCriteria)
        {
            var propertyInfos = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<AllowSearchAttribute>() != null).ToList();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(long))
                {
                    var value = (string)propertyInfo.GetValue(entity);
                    if (value != null && value.ToLower().Contains(searchCriteria.ToString().ToLower()))
                        return true;
                }
                else if (typeof(IEntity<long>).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    var result = SearchByAttribute(propertyInfo.GetValue(entity), searchCriteria);
                    if (result)
                        return true;
                }
            }
            return false;
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

        public object ExecuteStoredProcedure(string spName, Dictionary<string, string> parameters)
        {
            var paramstr = parameters.Aggregate(" ", (current, parameter) => current + string.Format(":{0}, ", parameter.Key));

            if (parameters.Count > 0)
                paramstr = paramstr.Remove(paramstr.Length - 2);

            var query = Session.CreateSQLQuery(string.Format("exec {0}{1}", spName, paramstr));

            foreach (var parameter in parameters)
                query.SetParameter(parameter.Key, parameter.Value);

            return query.SetResultTransformer(new DataTableResultTransformer()).List()[0];
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