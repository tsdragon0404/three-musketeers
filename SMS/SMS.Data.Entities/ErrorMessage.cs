namespace SMS.Data.Entities
{
    public class ErrorMessage : Entity
    {
        public virtual long BranchID { get; set; }

        public virtual string VNMessage { get; set; }

        public virtual string ENMessage { get; set; }
    }
}