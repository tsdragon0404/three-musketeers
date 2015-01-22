using System;
using System.Collections.Generic;
using Core.Common;
using SMS.Common.Storage;
using SMS.Data.Dtos.Inventory;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;
using AutoMapper;

namespace SMS.Business.Impl.Inventory
{
    public class ProductCategoryManagement : Business.Inventory.IProductCategoryManagement
    {
        public virtual IProductCategoryDA DA { get; set; }

        public List<ProductCategoryDto> GetList()
        {
            return Mapper.Map<List<ProductCategoryDto>>(DA.GetList());
        }

        public List<TModel> GetListForInventory<TModel>()
        {
            return Mapper.Map<List<TModel>>(DA.GetListForInventory());
        } 

        public ProductCategoryDto GetByID(long id)
        {
            return Mapper.Map<ProductCategoryDto>(DA.GetByID(id));
        }

        public ProductCategoryDto GetByIDForInventory(long id)
        {
            var cat = DA.GetByID(id);
            if (cat.BranchID != 0)
                throw new Exception();

            return Mapper.Map<ProductCategoryDto>(DA.GetByID(id));
        }

        public ProductCategoryDto Save(ProductCategoryDto item)
        {
            var entity = Mapper.Map<ProductCategory>(item);
            if (entity.ProductCategoryID == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
                return Mapper.Map<ProductCategoryDto>(DA.Insert(entity));
            }

            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedUser = SmsCache.UserContext.UserName;
            return Mapper.Map<ProductCategoryDto>(DA.Update(entity));
        }

        public ProductCategoryDto SaveForInventory(ProductCategoryDto item)
        {
            var entity = Mapper.Map<ProductCategory>(item);
            if (entity.ProductCategoryID == 0)
            {
                entity.BranchID = null;
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
                return Mapper.Map<ProductCategoryDto>(DA.Insert(entity));
            }

            if (entity.BranchID != null)
                throw new Exception();

            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedUser = SmsCache.UserContext.UserName;

            var propertyToUpdate = entity.GetPropertyNames(x => x.VNName, x => x.ENName, x => x.VNDescription, x => x.ENDescription,
                                                           x => x.SEQ, x => x.ModifiedDate, x => x.ModifiedUser);
            return Mapper.Map<ProductCategoryDto>(DA.Update(entity, propertyToUpdate));
        }

        public bool Delete(long id)
        {
            return DA.Delete(id);
        }

        public bool DeleteForInventory(long id)
        {
            GetByIDForInventory(id);
            return DA.Delete(id);
        }
    }
}