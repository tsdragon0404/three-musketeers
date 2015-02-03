using System.Collections.Generic;
using SMS.Business.Inventory;
using SMS.Data.Dtos;
using SMS.Services.Inventory;

namespace SMS.Services.Impl.Inventory
{
    public class DepotService : IDepotService
    {
        public virtual IDepotManagement Management { get; set; }

        public List<DepotDto> ListDepot()
        {
            return Management.ListDepot();
        }

        public DepotDto GetByID(long ID)
        {
            return Management.GetByID(ID);
        }

        public DepotDto Save(DepotDto item)
        {
            return Management.Save(item);
        }

        public bool Delete(long ID)
        {
            return Management.Delete(ID);
        }
    }
}