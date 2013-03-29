using System;

namespace TM.Framework.Data.Models
{
    public class Entity : EntityWithTypedId<Guid>
    {
    }

    public abstract class EntityWithTypedId<TIdentity> : IEntityWithTypedId<TIdentity>
    {
        #region IEntityWithTypedId<TIdentity> Members

        /// <summary>
        /// Gets or sets the identity value of entity.
        /// </summary>
        /// <value>The id.</value>
        /// <remarks>
        /// Id may be of type string, int, custom type, etc.
        /// Setter is protected to allow unit tests to set this property via reflection and to allow
        /// domain objects more flexibility in setting this for those objects with assigned Ids.
        /// It's virtual to allow NHibernate-backed objects to be lazily loaded.
        /// This is ignored for XML serialization because it does not have a public setter (which is very much by design).
        /// See the FAQ within the documentation if you'd like to have the Id XML serialized.
        /// </remarks>
        public virtual TIdentity Id { get; set; }

        /// <summary>
        /// Transient objects are not associated with an item already in storage.  For instance,
        /// a Customer is transient if its Id is 0.  It's virtual to allow NHibernate-backed
        /// objects to be lazily loaded.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsTransient()
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            return Id == null || Id.Equals(default(TIdentity));
            // ReSharper restore CompareNonConstrainedGenericWithNull
        }

        #endregion
    }
}
