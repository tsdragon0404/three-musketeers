﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Core.Common;
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

        /// <summary>
        /// execute stored procedure with param in
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteStoredProcedure(string spName, List<SpParameter> parameters)
        {
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = Session.Connection;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;
            parameters.ForEach(x => cmd.Parameters.Add(new SqlParameter(x.Name, x.Value)));

            Session.Transaction.Enlist(cmd);

            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            return dt;
        }

        /// <summary>
        /// execute stored procedure with param in-out
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="inParam"></param>
        /// <param name="outParam"></param>
        /// <returns>List out params return</returns>
        public Dictionary<string, string> ExecuteStoredProcedure(string spName, List<SpParameter> inParam, List<SpParameter> outParam)
        {
            IDbCommand cmd = new SqlCommand();

            cmd.Connection = Session.Connection;
            cmd.CommandType = CommandType.StoredProcedure;

            // set SP name
            cmd.CommandText = spName;

            // set input params
            inParam.ForEach(x => cmd.Parameters.Add(new SqlParameter(x.Name, x.Value)));

            // set output params
            outParam.ForEach(x => cmd.Parameters.Add(new SqlParameter(x.Name, x.Value) { Direction = ParameterDirection.Output }));

            Session.Transaction.Enlist(cmd);

            var dt = new Dictionary<string, string>();

            cmd.ExecuteNonQuery();
            outParam.ForEach(x => dt.Add(x.Name, ((SqlParameter)cmd.Parameters[x.Name]).Value.ToString().Trim()));

            return dt;
        }
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

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return GetQuery<TEntity>(predicate);
        }

        private IQueryable<TTargetEntity> GetQuery<TTargetEntity>(Expression<Func<TTargetEntity, bool>> predicate)
        {
            var query = Session.Query<TTargetEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        #endregion Methods
    }
}