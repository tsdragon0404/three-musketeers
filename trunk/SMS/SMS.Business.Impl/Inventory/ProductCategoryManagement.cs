using System;
using System.Collections.Generic;
using Core.Common;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;
using AutoMapper;

namespace SMS.Business.Impl.Inventory
{
    public class ProductCategoryManagement : Business.Inventory.IProductCategoryManagement
    {
        public virtual IProductCategoryDA DA { get; set; }

        public List<CategoryDto> GetList()
        {
            return Mapper.Map<List<CategoryDto>>(DA.GetList());
        }

        public List<TModel> GetListForInventory<TModel>()
        {
            return Mapper.Map<List<TModel>>(DA.GetListForInventory());
        } 

        public CategoryDto GetByID(long id)
        {
            return Mapper.Map<CategoryDto>(DA.GetByID(id));
        }

        public CategoryDto GetByIDForInventory(long id)
        {
            var cat = DA.GetByID(id);
            if (cat.BranchID != 0)
                throw new Exception();

            return Mapper.Map<CategoryDto>(DA.GetByID(id));
        }

        public CategoryDto Save(CategoryDto item)
        {
            var entity = Mapper.Map<ProductCategory>(item);
            if (entity.ProductCategoryID == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
                return Mapper.Map<CategoryDto>(DA.Insert(entity));
            }

            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedUser = SmsCache.UserContext.UserName;
            return Mapper.Map<CategoryDto>(DA.Update(entity));
        }

        public CategoryDto SaveForInventory(CategoryDto item)
        {
            var entity = Mapper.Map<ProductCategory>(item);
            if (entity.ProductCategoryID == 0)
            {
                entity.BranchID = null;
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUser = SmsCache.UserContext.UserName;
                return Mapper.Map<CategoryDto>(DA.Insert(entity));
            }

            if (entity.BranchID != null)
                throw new Exception();

            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedUser = SmsCache.UserContext.UserName;

            var propertyToUpdate = entity.GetPropertyNames(x => x.VNName, x => x.ENName, x => x.VNDescription, x => x.ENDescription,
                                                           x => x.SEQ, x => x.ModifiedDate, x => x.ModifiedUser);
            return Mapper.Map<CategoryDto>(DA.Update(entity, propertyToUpdate));
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