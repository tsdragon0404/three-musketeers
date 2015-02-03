using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("BRANCHINFO")]
    [PrimaryKey("ID")]
    public class BranchInfo
    {
        public long ID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public string Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
        public string Info8 { get; set; }
        public string Info9 { get; set; }
        public string Info10 { get; set; }
    }
}
