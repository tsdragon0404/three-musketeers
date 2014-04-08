using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Common;
using NHibernate.Criterion;

namespace Core.Data.NHibernate
{
    /// <summary>
    /// Provides a fully loaded data access component
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TIdentity">The type of the identity.</typeparam>
    public abstract class RepositoryWithTypedId<TEntity, TIdentity> :
        BaseRepository<TEntity>,
        IRepositoryWithTypedId
            <TEntity, TIdentity> where TEntity : class
    {
        #region Constructors and Destructors

        #endregion Constructors and Destructors

        #region IRepositoryWithTypedId<TEntity,TIdentity>

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual bool Delete(TIdentity key)
        {
            var entity = Session.Get<TEntity>(key);
            if (entity != null)
            {
                Session.Delete(entity);
            }
            return true;
        }

        /// <summary>
        /// Gets the entity with eager loading the selected properties by the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public virtual TEntity Get(TIdentity id,
                                   params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            var entity = Session.Get<TEntity>(id);

            FetchProperties(entity, fetchSelectors);

            return entity;
        }

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="fetchSelectors">The fetch selectors.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetByIds(IEnumerable<TIdentity> ids, params Expression<Func<TEntity, object>>[] fetchSelectors)
        {
            var entities = Session.CreateCriteria<TEntity>()
                .Add(new InExpression("Id", ids.OfType<object>().ToArray()))
                .List<TEntity>();
            entities.Apply(x => FetchProperties(x, fetchSelectors));

            return entities;
        }

        ///// <summary>
        ///// Updates the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        //public override void Update(TEntity entity)
        //{
        //    //entity = this.Session.Merge(entity) as TEntity;
        //    this.Session.Update(entity);

        //    //var oldEntity = this.Get(entity.GetValueByPropertyCaseInsensitive<TIdentity>("Id"));
        //    //this.Copy(entity, oldEntity);
        //    //this.Session.Update(oldEntity);
        //}

        /// <summary>
        /// Merges the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TEntity Merge(TEntity entity)
        {
            return this.Session.Merge(entity) as TEntity;
        }

        #endregion IRepositoryWithTypedId<TEntity,TIdentity>
    }
}