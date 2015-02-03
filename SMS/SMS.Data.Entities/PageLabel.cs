using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("PAGELABEL")]
    [PrimaryKey("ID")]
    public class PageLabel
    {
        public long ID { get; set; }
        public long BranchID { get; set; }
        public string LabelID { get; set; }
        public long PageID { get; set; }
        public string VNText { get; set; }
        public string ENText { get; set; }
    }
}