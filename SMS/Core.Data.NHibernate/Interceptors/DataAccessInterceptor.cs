using System;
using Castle.DynamicProxy;
using Core.Common.Exceptions;

namespace Core.Data.NHibernate.Interceptors
{
    public class DataAccessInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try { invocation.Proceed(); }
            catch (Exception ex)
            {
                var exception = new DataAccessException { InnerException = ex };
                throw exception;
            }
        }
    }
}