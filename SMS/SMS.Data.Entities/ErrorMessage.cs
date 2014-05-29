using Core.Data;

namespace SMS.Data.Entities
{
    public class ErrorMessage : Entity
    {
        public virtual string VNMessage { get; set; }

        public virtual string ENMessage { get; set; }
    }
}