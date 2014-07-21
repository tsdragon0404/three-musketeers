using System.Collections.Generic;
using Core.Common.Validation;

namespace Core.Data
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
        IList<Error> Errors { get; set; }

        bool IsValid();
    }

    public abstract class EntityWithTypedId<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey ID { get; set; }
        public virtual IList<Error> Errors { get; set; }

        public abstract bool IsValid();
    }
}