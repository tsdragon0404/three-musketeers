using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SMS.Data
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> ListAll(bool includeDisable = false);
        IEnumerable<TEntity> ListAllByBranch(long branchID, bool includeDisable = false);
        IEnumerable<TEntity> ListByIDs(IEnumerable<long> ids);
        IEnumerable<TEntity> Search(string textSearch, bool includeDisable = false);
        IEnumerable<TEntity> SearchInBranch(string textSearch, long branchID, bool includeDisable = false);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetByID(long primaryKey);
        TEntity GetByIDInCurrentBranch(long primaryKey);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        bool ExistsInCurrentBranch(Expression<Func<TEntity, bool>> predicate);
        bool Delete(long primaryKey);
        bool DeleteInCurrentBranch(long primaryKey);
        void Save(TEntity entity);

        TTargetEntity CrossTableGetByID<TTargetEntity>(object id);
        TTargetEntity CrossTableGet<TTargetEntity>(Expression<Func<TTargetEntity, bool>> predicate);
        IEnumerable<TTargetEntity> CrossTableList<TTargetEntity>(Expression<Func<TTargetEntity, bool>> predicate);
        void CrossTableAdd(object item);
        void CrossTableUpdate(object item);
        void CrossTableDelete<TTargetEntity>(object id);
    }
}