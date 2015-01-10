using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common;
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

        private static string TableName
        {
            get
            {
                var tableNameAtt = typeof (TEntity).GetAttributes<TableNameAttribute>(false).FirstOrDefault();
                return tableNameAtt == null ? typeof (TEntity).Name : tableNameAtt.Value;
            }
        }

        private static string PrimaryKeyColumn
        {
            get
            {
                var primaryKeyAtt = typeof(TEntity).GetAttributes<PrimaryKeyAttribute>(false).FirstOrDefault();
                return primaryKeyAtt == null ? typeof(TEntity).Name + "ID" : primaryKeyAtt.Value;
            }
        }

        private static string SelectQuery
        {
            get { return "SELECT * FROM " + TableName; }
        }

        #region Implementation of IBaseDA<TEntity>

        public virtual IList<TEntity> ListAll(bool includeDisable = false)
        {
            var db = new Database(config);
            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                return db.Query<TEntity>(SelectQuery + " WHERE Enable = 1").ToList();

            return db.Query<TEntity>(SelectQuery).ToList();
        }

        public virtual IList<TEntity> ListByIDs(IEnumerable<long> ids)
        {
            var db = new Database(config);
            var sql = string.Format("{0} WHERE {1} IN {2}", SelectQuery, PrimaryKeyColumn, ids.ToSqlInClause());
            return db.Query<TEntity>(sql).ToList();
        }

        public virtual TEntity GetByID(long primaryKey)
        {
            var db = new Database(config);
            var sql = string.Format("{0} WHERE {1} = {2}", SelectQuery, PrimaryKeyColumn, primaryKey);
            return db.SingleOrDefault<TEntity>(sql);
        }

        public virtual bool Delete(long primaryKey)
        {
            var db = new Database(config);
            return db.Delete<TEntity>(primaryKey) > 0;
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

        #endregion
    }
}
