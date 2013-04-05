using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using TM.Framework.Models;

namespace TM.Framework.NHibernate
{
    /// <summary>
    /// Provides a fully loaded data access component for any entity
    /// </summary>
    public abstract class BaseNHibernateRepository
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNHibernateRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        protected BaseNHibernateRepository()
        {
            InitializeSessionFactory();
        }

        #endregion Constructors and Destructors

        #region Properties

        protected abstract string ConnectionStringName { get; set; }

        private ISessionFactory _sessionFactory;

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        #endregion Properties

        protected abstract void InitializeSessionFactory();

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }


    /// <summary>
    /// Provides a fully loaded data access component
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public abstract class BaseNHibernateRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNHibernateRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        protected BaseNHibernateRepository()
        {
            BuildSessionFactory();
        }

        #endregion Constructors and Destructors

        #region Properties

        protected abstract string ConnectionString { get; }

        private ISessionFactory _sessionFactory;

        private ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = BuildSessionFactory()); }
        }

        #endregion Properties

        protected abstract ISessionFactory BuildSessionFactory();

        private ISession _session;
        public ISession Session
        {
            get
            {
                if (_session == null || !_session.IsConnected || !_session.IsOpen)
                    _session = SessionFactory.OpenSession();
                return _session;
            }
        }

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
        /// Copies the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public void Copy(TEntity source, TEntity target)
        {
            var metadata = Session.SessionFactory.GetClassMetadata(typeof(TEntity));
            var values = metadata.GetPropertyValues(source, EntityMode.Poco);
            metadata.SetPropertyValues(target, values, EntityMode.Poco);
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
            return Fetches(GetQuery(predicate), fetchSelectors).ToList();
        }

        #region Orderable
        ///// <summary>
        ///// Finds entities by the specified predicate and orders.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="order">The order.</param>
        ///// <param name="fetchSelectors">The fetch selectors.</param>
        ///// <returns></returns>
        //public IEnumerable<TEntity> Find(
        //    Expression<Func<TEntity, bool>> predicate,
        //    Action<IOrderable<TEntity>> order,
        //    params Expression<Func<TEntity, object>>[] fetchSelectors)
        //{
        //    return Fetches(GetQuery(predicate, order), fetchSelectors).ToList();
        //}

        ///// <summary>
        ///// Finds entities by the specified predicate, order and paging.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="order">The order.</param>
        ///// <param name="pageNumber">The page number, start from 1</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <param name="totalCount">The total count.</param>
        ///// <param name="fetchSelectors">The fetch selectors.</param>
        ///// <returns></returns>
        //public IEnumerable<TEntity> Find(
        //    Expression<Func<TEntity, bool>> predicate,
        //    Action<IOrderable<TEntity>> order,
        //    int pageNumber,
        //    int pageSize,
        //    out int totalCount,
        //    params Expression<Func<TEntity, object>>[] fetchSelectors)
        //{
        //    totalCount = Count(predicate);
        //    return
        //        Fetches(GetQuery(predicate, order), fetchSelectors).Skip(pageNumber * pageSize).Take(pageSize).ToList();
        //} 
        ///// <summary>
        ///// Gets all.
        ///// </summary>
        ///// <param name="order">The order.</param>
        ///// <param name="pageNumber">The page number.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <param name="totalCount">The total count.</param>
        ///// <param name="fetchSelectors">The fetch selectors.</param>
        ///// <returns></returns>
        //public IEnumerable<TEntity> GetAll(
        //    Action<IOrderable<TEntity>> order,
        //    int pageNumber,
        //    int pageSize,
        //    out int totalCount,
        //    params Expression<Func<TEntity, object>>[] fetchSelectors)
        //{
        //    return Find(null, order, pageNumber, pageSize, out totalCount, fetchSelectors);
        //}
        public IQueryable<TEntity> GetQuery(
            Expression<Func<TEntity, bool>> predicate = null)//, Action<IOrderable<TEntity>> order = null)
        {
            var query = Session.Query<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            //if (order != null)
            //{
            //    var orderable = new NHibernateOrderable<TEntity>(query);
            //    order(orderable);
            //    query = orderable.Query;
            //}

            return query;
        }
        #endregion

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
            return Fetches(Session.Query<TEntity>(), fetchSelectors).ToList();
        }

        /// <summary>
        /// Queries the other.
        /// </summary>
        /// <typeparam name="TEntity1">The type of the entity1.</typeparam>
        /// <returns></returns>
        public IQueryable<TEntity1> GetQueryOther<TEntity1>()
        {
            return Session.Query<TEntity1>();
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

        #endregion Methods
    }
}
