using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("PAGE")]
    [PrimaryKey("ID")]
    public class Page
    {
        public long ID { get; set; }
        public string VNTitle { get; set; }
        public string ENTitle { get; set; }
        public string VNDescription { get; set; }
        public string ENDescription { get; set; }
        public PageType Type { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool Enable { get; set; }
    }
}