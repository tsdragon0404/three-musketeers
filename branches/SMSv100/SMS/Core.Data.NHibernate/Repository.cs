using System;
using Core.Common;
using NHibernate.Persister.Entity;

namespace Core.Data.NHibernate
{
    /// <summary>
    /// Since nearly all of the domain objects you create will have a type of Guid Id, this
    /// most frequently used base repository leverages this assumption.  If you want an entity
    /// with a type other than integer, such as string, then use
    /// <see cref="RepositoryWithTypedId{TEntity,TIdentity}"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : RepositoryWithTypedId<TEntity, long>,
                                                 IRepository<TEntity> where TEntity : class
    {
        #region Constructors and Destructors

        #endregion Constructors and Destructors

        #region Methods

        public string GetDatabaseSchemaTableName(Type type)
        {
            var hibernateMetadata = Session.SessionFactory.GetClassMetadata(type);

            if (hibernateMetadata == null)
            {
                return string.Empty;
            }
            var persister = hibernateMetadata as AbstractEntityPersister;
            return persister != null ? persister.TableName : string.Empty;
        }

        public string GetPrimaryKey(Type type)
        {
            var hibernateMetadata = Session.SessionFactory.GetClassMetadata(type);

            if (hibernateMetadata == null)
            {
                return string.Empty;
            }
            var persister = hibernateMetadata as AbstractEntityPersister;
            return persister != null ? persister.IdentifierColumnNames.Join(", ") : string.Empty;
        } 

        #endregion
    }


}
