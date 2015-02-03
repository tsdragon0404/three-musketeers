using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("ERRORMESSAGE")]
    [PrimaryKey("ID")]
    public class ErrorMessage
    {
        public long ID { get; set; }
        public long MessageID { get; set; }
        public string VNMessage { get; set; }
        public string ENMessage { get; set; }
        public long BranchID { get; set; }
    }
}