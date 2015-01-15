using System;
using System.Linq;
using Core.Data;
using Core.Data.PetaPoco;
using SMS.Common;
using SMS.Common.Storage;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public abstract class EntityDA<TEntity> : BaseDA, IEntityDA<TEntity>
    {
        protected SqlStatementDictionary SqlStatement 
        { 
            get { return ServerCache.Get<SqlStatementDictionary>(CacheKey.SqlStatement); } 
        }

        protected EntityDA(IConfig config, ISqlStatementDA sqlStatementDA) : base(config)
        {
            if(!ServerCache.Exists(CacheKey.SqlStatement))
                ServerCache.Add(CacheKey.SqlStatement, () => GetSqlStatementCallback(sqlStatementDA));
        }

        private SqlStatementDictionary GetSqlStatementCallback(ISqlStatementDA sqlStatementDA)
        {
            var statements = sqlStatementDA.GetListStatement();
            return new SqlStatementDictionary(statements.ToDictionary(x => x.Name, x => x.QueryString));
        }

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
