using System;
using Castle.DynamicProxy;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Data.NHibernate.Interceptors
{
    public class BusinessInterceptor : IInterceptor
    {
        private ISessionFactory SessionFactory { get; set; }

        public BusinessInterceptor(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }
        public void Intercept(IInvocation invocation)
        {
            //If there is a running transaction, just run the method
            if (UnitOfWork.Current != null)
            {
                invocation.Proceed();
                return;
            }

            try
            {
                UnitOfWork.Current = new UnitOfWork(SessionFactory);
                UnitOfWork.Current.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    UnitOfWork.Current.Commit();
                }
                catch
                {
                    try
                    {
                        UnitOfWork.Current.Rollback();
                    }
                    catch
                    {

                    }

                    throw;
                }
            }
            finally
            {
                UnitOfWork.Current = null;
            }
        }
    }
}