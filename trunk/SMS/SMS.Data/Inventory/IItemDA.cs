using System.Collections.Generic;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface IItemDA
    {
        List<Item> GetList(bool isEnable = true);
        Item GetByID(long itemID);
        Item Save(Item item);
        bool Delete(long itemID);
    }
}