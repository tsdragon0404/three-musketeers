﻿using System;
using System.Collections.Generic;
using SMS.Business.Inventory;
using SMS.Common.Storage;
using SMS.Data.Dtos.Inventory;
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
            }
            else
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedUser = SmsCache.UserContext.UserName;
            }

            return Mapper.Map<DepotDto>(DA.Save(entity));
        }

        public bool Delete(long ID)
        {
            return DA.Delete(ID);
        }
    }
}