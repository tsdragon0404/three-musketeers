using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Data;
using Core.Data.NHibernate;
using SMS.Common.Storage;
using SMS.Data.Entities;
using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Impl
{
    public class BaseRepository<TEntity> : Repository<TEntity>,
                                           IBaseRepository<TEntity> where TEntity : Entity
    {
        #region Func

        public virtual Func<TEntity, long, bool> BelongToBranch
        {
            get
            {
                if (typeof(IBranchEntity).IsAssignableFrom(typeof(TEntity)))
                    return (x, y) => ((IBranchEntity)x).Branch != null && ((IBranchEntity)x).Branch.ID == y;

                throw new NotImplementedException("BelongToBranch function is not defined");
            }
        }

        public virtual Func<TEntity, bool> BelongToCurrentBranch
        {
            get
            {
                if (BelongToBranch != null)
                    return x => BelongToBranch(x, SmsCache.UserContext.CurrentBranchId);

                return null;
            }
        }

        public virtual Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> ExecuteOrderFunc
        {
            get { return null; }
        }

        #endregion

        public override void Add(TEntity entity)
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditableEntity)entity).CreatedDate = DateTime.Now;
                ((IAuditableEntity)entity).CreatedUser = SmsCache.UserContext.UserName;
            }

            base.Add(entity);
        }

        public override void Update(TEntity entity)
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditableEntity)entity).ModifiedDate = DateTime.Now;
                ((IAuditableEntity)entity).ModifiedUser = SmsCache.UserContext.UserName;
            }

            base.Update(entity);
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return Find(predicate);
        }

        public virtual IEnumerable<TEntity> ListAll(bool includeDisable = false)
        {
            IEnumerable<TEntity> result;
            
            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                result = Find(x => (x as IEnableEntity).Enable);
            else
                result = GetAll();

            if (ExecuteOrderFunc != null)
                result = ExecuteOrderFunc(result);

            return result;
        }

        public virtual IEnumerable<TEntity> ListAllByBranch(long branchID, bool includeDisable = false)
        {
            return ListAll(includeDisable).Where(x => BelongToBranch(x, branchID));
        }

        public IEnumerable<TEntity> ListByIDs(IEnumerable<long> ids)
        {
            return List(x => ids.Contains(x.ID));
        }

        public virtual IEnumerable<TEntity> Search(string textSearch, bool includeDisable = false)
        {
            IEnumerable<TEntity> result;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                result = FindByString(textSearch, x => (x as IEnableEntity).Enable);
            else
                result = FindByString(textSearch, null);

            if (ExecuteOrderFunc != null)
                result = ExecuteOrderFunc(result);

            return result;
        }

        public virtual IEnumerable<TEntity> SearchInBranch(string textSearch, long branchID, bool includeDisable = false)
        {
            var result = Search(textSearch, includeDisable).Where(x => BelongToBranch(x, branchID)).ToList();

            return result;
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return FindOne(predicate);
        }

        public virtual TEntity GetByID(long primaryKey)
        {
            return Get(primaryKey);
        }

        public virtual TEntity GetByIDInCurrentBranch(long primaryKey)
        {
            var record = Get(primaryKey);
            if (record == null || !BelongToCurrentBranch(record))
                return null;

            return record;
        }

        public new virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return base.Exists(predicate);
        }

        public virtual bool ExistsInCurrentBranch(Expression<Func<TEntity, bool>> predicate)
        {
            return List(predicate).Any();
        }

        public new virtual bool Delete(long primaryKey)
        {
            return base.Delete(primaryKey);
        }

        public virtual bool DeleteInCurrentBranch(long primaryKey)
        {
            var record = Get(primaryKey);
            return BelongToCurrentBranch(record) && Delete(primaryKey);
        }

        public virtual void Save(TEntity entity)
        {
            if (entity is IBranchEntity)
                (entity as IBranchEntity).Branch = new Entities.Branch { ID = SmsCache.UserContext.CurrentBranchId };

            if (entity.ID == 0)
                Add(entity);
            else
            {
                var mergeEntity = Merge(entity);
                Update(mergeEntity);
                entity = mergeEntity;
            }
        }
    }
}
