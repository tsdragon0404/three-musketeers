using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface IDepotDA
    {
        List<Depot> ListDepot(bool isEnable = true);
        Depot GetByID(long ID);
        Depot Insert(Depot depot);
        Depot Update(Depot depot, params string[] columns);
        bool Delete(long ID);
    }
}