using System;
using Core.Data;
using Core.Data.PetaPoco;
using SMS.Common.Storage;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public abstract class EntityDA<TEntity> : BaseDA, IEntityDA<TEntity>
    {
        protected EntityDA(IConfig config) : base(config)
        {}

        public virtual bool Delete(long primaryKey)
        {
            return DAHelper.Delete<TEntity>(config, primaryKey);
        }

        public virtual void Save(TEntity entity)
        {
            var db = new Database(config);

            if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                if (db.IsNew(entity))
                    ((IAuditableEntity)entity).CreatedDate = DateTime.Now;
                else
                    ((IAuditableEntity)entity).ModifiedDate = DateTime.Now;

                ((IAuditableEntity)entity).CreatedUser = SmsCache.UserContext.UserName;
            }

            db.Save(entity);
        }
    }
}
