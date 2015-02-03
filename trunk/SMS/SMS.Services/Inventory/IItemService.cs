using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services.Inventory
{
    public interface IItemService
    {
        List<ItemDto> GetList();
        ItemDto GetByID(long itemID);
        ItemDto Save(ItemDto item);
        bool Delete(long itemID);
    }
}