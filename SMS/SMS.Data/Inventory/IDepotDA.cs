using System.Collections.Generic;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface IDepotDA
    {
        List<Depot> ListDepot(bool isEnable = true);
        Depot GetByID(long ID);
        Depot Save(Depot item);
        bool Delete(long ID);
    }
}