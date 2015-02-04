using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface IItemDA
    {
        List<Item> GetList(bool isEnable = true);
        Item GetByID(long itemID);
        Item Insert(Item item);
        Item Update(Item item, params string[] columns);
        bool Delete(long itemID);
    }
}