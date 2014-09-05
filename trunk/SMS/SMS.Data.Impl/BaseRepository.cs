using System;
using Core.Data;
using Core.Data.NHibernate;
using SMS.Common.Session;

namespace SMS.Data.Impl
{
    public class BaseRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public override void Add(TEntity entity)
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditableEntity)entity).CreatedDate = DateTime.Now;
                ((IAuditableEntity)entity).CreatedUser = SmsSystem.UserContext.UserName;
            }

            base.Add(entity);
        }

        public override void Update(TEntity entity)
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditableEntity)entity).ModifiedDate = DateTime.Now;
                ((IAuditableEntity)entity).ModifiedUser = SmsSystem.UserContext.UserName;
            }

            base.Update(entity);
        }
    }
}
