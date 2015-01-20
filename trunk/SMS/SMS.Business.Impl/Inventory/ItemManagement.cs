using System;
using System.Collections.Generic;
using SMS.Business.Inventory;
using SMS.Common.Storage;
using SMS.Data.Dtos.Inventory;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;
using AutoMapper;

namespace SMS.Business.Impl.Inventory
{
    public class ItemManagement : IItemManagement
    {
        public virtual IItemDA DA { get; set; }

        public List<ItemDto> ListItem()
        {
            return Mapper.Map<List<ItemDto>>(DA.ListItem());
        }

        public ItemDto GetByID(long itemID)
        {
            return Mapper.Map<ItemDto>(DA.GetByID(itemID));
        }

        public ItemDto Save(ItemDto item)
        {
            var entity = Mapper.Map<Item>(item);
            if (entity.ItemID == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
            }
            else
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedUser = SmsCache.UserContext.UserName;
            }

            return Mapper.Map<ItemDto>(DA.Save(entity));
        }

        public bool Delete(long itemID)
        {
            return DA.Delete(itemID);
        }
    }
}