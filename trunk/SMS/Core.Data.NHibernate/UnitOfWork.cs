using System;
using NHibernate;
using NHibernate.Context;

namespace Core.Data.NHibernate
{
    /// <summary>
    /// Implements Unit of work for NHibernate.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        /// <summary>
        /// Gets current instance of the NHibernateUnitOfWork.
        /// It gets the right instance that is related to current thread.
        /// </summary>
        public static UnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        [ThreadStatic]
        private static UnitOfWork _current;

        /// <summary>
        /// Gets Nhibernate session object to perform queries.
        /// </summary>
        public ISession Session { get; private set; }

        /// <summary>
        /// Reference to the session factory.
        /// </summary>
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Reference to the currently running transcation.
        /// </summary>
        private ITransaction _transaction; 

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of UnitOfWork.
        /// </summary>
        /// <param name="sessionFactory"></param>
        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        } 

        #endregion
    }
}
