﻿using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using AutoMapper;
using SMS.Common.Constant;
using SMS.Common.Storage;

namespace SMS.Business.Impl
{
    public abstract class BaseManagement<TDto, TEntity, TIRepository> : IBaseManagement<TDto> 
        where TIRepository : Data.IBaseRepository<TEntity> 
    {
        public virtual TIRepository Repository { get; set; }

        #region Implementation of IBaseManagement<TDto,in TPrimaryKey>

        public virtual ServiceResult<IList<TDto>> ListAll(bool includeDisable)
        {
            return ListAll<TDto>(includeDisable);
        }

        public virtual ServiceResult<IList<TModel>> ListAll<TModel>(bool includeDisable = false)
        {
            var result = Repository.ListAll(includeDisable);

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public virtual ServiceResult<IList<TDto>> ListAllByBranch(long branchID, bool includeDisable)
        {
            return ListAllByBranch<TDto>(branchID, includeDisable);
        }

        public virtual ServiceResult<IList<TModel>> ListAllByBranch<TModel>(long branchID, bool includeDisable)
        {
            var result = Repository.ListAllByBranch(branchID, includeDisable);

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public virtual ServiceResult<TDto> GetByID(long primaryKey)
        {
            return GetByID<TDto>(primaryKey);
        }

        public virtual ServiceResult<TModel> GetByID<TModel>(long primaryKey)
        {
            var result = Repository.GetByID(primaryKey);
            return result == null
                ? ServiceResult<TModel>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business))
                : ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(result));
        }

        public virtual ServiceResult<TDto> GetByIDInCurrentBranch(long primaryKey)
        {
            return GetByIDInCurrentBranch<TDto>(primaryKey);
        }

        public virtual ServiceResult<TModel> GetByIDInCurrentBranch<TModel>(long primaryKey)
        {
            var result = Repository.GetByIDInCurrentBranch(primaryKey);

            return result == null
               ? ServiceResult<TModel>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business))
               : ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(result));
        }

        public virtual ServiceResult Delete(long primaryKey)
        {
            return ServiceResult.CreateResult(Repository.Delete(primaryKey));
        }

        public virtual ServiceResult DeleteInCurrentBranch(long primaryKey)
        {
            var result = Repository.DeleteInCurrentBranch(primaryKey);

            return result
                ? ServiceResult.CreateSuccessResult()
                : ServiceResult.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));
        }

        public virtual ServiceResult<TDto> Save(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            Repository.Save(entity);

            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(entity));
        }

        #endregion
    }
}