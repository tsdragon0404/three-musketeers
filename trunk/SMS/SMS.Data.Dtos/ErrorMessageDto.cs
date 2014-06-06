namespace SMS.Data.Dtos
{
    public class ErrorMessageDto 
    {
        public virtual long ID { get; set; }

        public virtual long BranchID { get; set; }

        public virtual string VNMessage { get; set; }

        public virtual string ENMessage { get; set; }
    }
}