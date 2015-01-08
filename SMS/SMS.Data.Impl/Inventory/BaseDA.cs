using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Common;
using Core.Data.PetaPoco;
using SMS.Common.Storage;
using SMS.Data.Entities.Interfaces;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public abstract class BaseDA<TEntity> : IBaseDA<TEntity>
    {
        #region Variables

        private readonly IConfig config;

        #endregion

        protected BaseDA(IConfig config)
        {
            this.config = config;
        }

        private static string TableName
        {
            get
            {
                var tableNameAtt = typeof (TEntity).GetAttributes<TableNameAttribute>(false).FirstOrDefault();
                return tableNameAtt == null ? typeof (TEntity).Name : tableNameAtt.Value;
            }
        }

        #region Implementation of IBaseDA<TEntity>

        public void ExecuteCommand(string sql)
        {
            var db = new Database(config);
            db.Execute(sql);
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            var db = new Database(config);
            var sql = Sql.Builder
                .Append("SELECT * FROM " + typeof (TEntity).Name)
                .Append("WHERE " + DAHelper.TranslateExpression(predicate));

            return db.Query<TEntity>(sql);
        }

        public virtual IEnumerable<TEntity> ListAll(bool includeDisable = false)
        {
            var db = new Database(config);
            return db.Query<TEntity>("SELECT * FROM " + TableName);
        }

        public virtual IEnumerable<TEntity> ListByIDs(IEnumerable<long> ids)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetByID(long primaryKey)
        {
            throw new NotImplementedException();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(long primaryKey)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(TEntity entity)
        {
            var db = new Database(config);
            db.Save(entity);
        }

        #endregion
    }
}
