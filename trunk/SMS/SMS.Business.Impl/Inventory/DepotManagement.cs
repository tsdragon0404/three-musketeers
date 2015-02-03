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
    public class DepotManagement : IDepotManagement
    {
        public virtual IDepotDA DA { get; set; }

        public List<DepotDto> ListDepot()
        {
            return Mapper.Map<List<DepotDto>>(DA.ListDepot());
        }

        public DepotDto GetByID(long ID)
        {
            return Mapper.Map<DepotDto>(DA.GetByID(ID));
        }

        public DepotDto Save(DepotDto item)
        {
            var entity = Mapper.Map<Depot>(item);
            if (entity.ID == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
                return Mapper.Map<DepotDto>(DA.Insert(entity));
            }

            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedUser = SmsCache.UserContext.UserName;

            var propertyToUpdate = entity.GetPropertyNames(x => x.DepotName, x => x.Phone, x => x.Fax, x => x.Email,
                                                           x => x.Address, x => x.SEQ, x => x.ModifiedDate, x => x.ModifiedUser);
            return Mapper.Map<DepotDto>(DA.Update(entity, propertyToUpdate));
        }

        public bool Delete(long ID)
        {
            return DA.Delete(ID);
        }
    }
}