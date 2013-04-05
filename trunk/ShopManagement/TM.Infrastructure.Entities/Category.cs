using System;
using TM.Framework.Models;

namespace TM.Infrastructure.Entities
{
    public class Category : Entity
    {
        public virtual string CategoryName { get; set; }
    }
}
