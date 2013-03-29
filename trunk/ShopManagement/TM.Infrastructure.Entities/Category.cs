using System;
using TM.Framework.Data.Models;

namespace TM.Infrastructure.Entities
{
    public class Category : Entity
    {
        public virtual string CategoryName { get; set; }
    }
}
