using System.Collections.Generic;
using SMS.Data.Dtos;

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