using System;
using System.Collections.Generic;
using Core.Common;
using SMS.Business.Inventory;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;
using AutoMapper;

namespace SMS.Business.Impl.Inventory
{
    public class ItemManagement : IItemManagement
    {
        public virtual IItemDA DA { get; set; }

        public List<ItemDto> GetList()
        {
            return Mapper.Map<List<ItemDto>>(DA.GetList());
        }

        public ItemDto GetByID(long itemID)
        {
            return Mapper.Map<ItemDto>(DA.GetByID(itemID));
        }

        public ItemDto Save(ItemDto item)
        {
            var entity = Mapper.Map<Item>(item);
            if (entity.ID == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
                return Mapper.Map<ItemDto>(DA.Insert(entity));
            }

            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedUser = SmsCache.UserContext.UserName;
            var propertyToUpdate = entity.GetPropertyNames(x => x.VNName, x => x.ENName, x => x.VNDescription, x => x.ENDescription, 
                                                           x => x.UnitID, x => x.ProductCategoryID, x => x.IsInventory, x => x.MinQuantity, 
                                                           x => x.SEQ, x => x.ModifiedDate, x => x.ModifiedUser);
            return Mapper.Map<ItemDto>(DA.Update(entity, propertyToUpdate));
        }

        public bool Delete(long itemID)
        {
            return DA.Delete(itemID);
        }
    }
}