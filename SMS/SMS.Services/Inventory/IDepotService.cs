
using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services.Inventory
{
    public interface IDepotService
    {
        List<DepotDto> ListDepot();
        DepotDto GetByID(long itemID);
        DepotDto Save(DepotDto item);
        bool Delete(long itemID);
    }
}