using System;
using System.Data;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Persister.Entity;
using TM.Framework.Models;
using TM.Framework.NHibernate;

namespace TM.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Since nearly all of the domain objects you create will have a type of Guid Id, this
    /// most frequently used base repository leverages this assumption.  If you want an entity
    /// with a type other than integer, such as string, then use
    /// <see cref="NHibernateRepositoryWithTypedId{TEntity,TIdentity}"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class NHibernateRepository<TEntity> : NHibernateRepositoryWithTypedId<TEntity, Guid>,
                                                 IRepository<TEntity> where TEntity : class
    {
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
            if (hibernateMetadata is AbstractEntityPersister)
            {
                var persister = (AbstractEntityPersister)hibernateMetadata;
                return persister.IdentifierColumnNames.Join(", ");
            }

            return string.Empty;
        }

        protected override string ConnectionString 
        {
            get { return @"Data Source=.;Initial Catalog=ShopManagement;User ID=sa;Password=123456"; }
        }

        protected override ISessionFactory BuildSessionFactory()
        {
            var mappingAssembly = Assembly.Load("TM.Infrastructure.Data");
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(connstr => connstr.Is(ConnectionString))
                              .IsolationLevel(IsolationLevel.ReadCommitted)
                )
                .Mappings(mappings => mappings.FluentMappings.AddFromAssembly(mappingAssembly))
                .BuildSessionFactory();
        }
    }
}
