using System.Collections.Generic;
using SMS.Data.Dtos.Inventory;

namespace SMS.Business.Inventory
{
    public interface IDepotManagement
    {
        List<DepotDto> ListDepot();
        DepotDto GetByID(long ID);
        DepotDto Save(DepotDto item);
        bool Delete(long ID);
    }
}