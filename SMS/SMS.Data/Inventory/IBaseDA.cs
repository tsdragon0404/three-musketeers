using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SMS.Data.Inventory
{
    public interface IBaseDA<TEntity>
    {
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> ListAll(bool includeDisable = false);
        IEnumerable<TEntity> ListByIDs(IEnumerable<long> ids);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetByID(long primaryKey);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        bool Delete(long primaryKey);
        void Save(TEntity entity);

        void ExecuteCommand(string sql);
    }
}