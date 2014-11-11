using Core.Data;
using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class BaseMap<T> : ClassMap<T>
    {
         protected BaseMap()
         {
             var type = typeof(T);

             if (type.IsSubclassOf(typeof(Entity)))
             {
                 Id(x => (x as Entity).ID).Column(string.Format("{0}ID", GetName())).GeneratedBy.Identity();
             }
             if (typeof(IAuditableEntity).IsAssignableFrom(type))
             {
                 Map(x => (x as IAuditableEntity).CreatedUser).Not.Update();
                 Map(x => (x as IAuditableEntity).CreatedDate).Not.Update();
                 Map(x => (x as IAuditableEntity).ModifiedUser);
                 Map(x => (x as IAuditableEntity).ModifiedDate);
             }
             if (typeof(ISortableEntity).IsAssignableFrom(type))
             {
                 Map(x => (x as ISortableEntity).SEQ);
             }
             if (typeof(IEnableEntity).IsAssignableFrom(type))
             {
                 Map(x => (x as IEnableEntity).Enable);
             }
         }

        protected string GetName()
        {
            return typeof (T).Name;
        }
    }
}