using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("PAGEMENU")]
    [PrimaryKey("ID")]
    public class PageMenu
    {
        public long ID { get; set; }
        public string GroupName { get; set; }
        public long PageID { get; set; }
        public long ParentID { get; set; }
        public int SEQ { get; set; }
    }
}