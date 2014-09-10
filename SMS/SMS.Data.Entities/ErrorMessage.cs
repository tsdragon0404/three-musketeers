namespace SMS.Data.Entities
{
    public class ErrorMessage : Entity
    {
        public virtual long MessageID { get; set; }

        public virtual string VNMessage { get; set; }

        public virtual string ENMessage { get; set; }

        public virtual long BranchID { get; set; }
    }
}