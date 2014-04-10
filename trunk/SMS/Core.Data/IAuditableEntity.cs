using System;

namespace Core.Data
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        string CreatedUser { get; set; }

        DateTime ModifiedDate { get; set; }

        string ModifiedUser { get; set; }
    }
}