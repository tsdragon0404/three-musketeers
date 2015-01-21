using System;

namespace SMS.Data.Dtos.Inventory
{
    public class DepotDto : EnableSortableDto
    {
        public long ID { get; set; }
        public string DepotCode { get; set; }
        public string DepotName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
