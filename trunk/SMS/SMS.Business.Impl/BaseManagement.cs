﻿using System.Collections.Generic;
using System.Linq;
using Core.Common.Session;
using Core.Common.Validation;
using Core.Data;
using AutoMapper;
using SMS.Common.Paging;

namespace SMS.Business.Impl
{
    public class BaseManagement<TDto, TEntity, TPrimaryKey, TIRepository> : IBaseManagement<TDto, TPrimaryKey> 
        where TIRepository : IRepositoryWithTypedId<TEntity, TPrimaryKey> 
        where TEntity: IEntity<TPrimaryKey>
    {
        public virtual TIRepository Repository { get; set; }

        #region Implementation of IBaseManagement<TDto,in TPrimaryKey>

        public IList<TDto> GetAll()
        {
            return Mapper.Map<IList<TDto>>(Repository.GetAll().ToList());
        }

        public IList<TModel> GetAll<TModel>()
        {
            return Mapper.Map<IList<TModel>>(Repository.GetAll().ToList());
        }

        public IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TDto>>(Repository.FindByString(textSearch));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = UserContext.PageSize;

            return PagedList<TDto>.CreatePageList(filteredRecords, pagingInfo);
        }

        public IPagedList<TModel> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TModel>>(Repository.FindByString(textSearch));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = UserContext.PageSize;

            return PagedList<TModel>.CreatePageList(filteredRecords, pagingInfo);
        }

        public TDto GetByID(TPrimaryKey primaryKey)
        {
            return Mapper.Map<TDto>(Repository.Get(primaryKey));
        }

        public TModel GetByID<TModel>(TPrimaryKey primaryKey)
        {
            return Mapper.Map<TModel>(Repository.Get(primaryKey));
        }

        public ServiceResult<TDto> Save(TDto dto)
        {
            var result = new ServiceResult<TDto>();

            var entity = Mapper.Map<TEntity>(dto);
            if (entity.ID is long && long.Parse(entity.ID.ToString()) == 0)
                Repository.Add(entity);
            else
            {
                var mergeEntity = Repository.Merge(entity);
                Repository.Update(mergeEntity);
            }
            result.Data = Mapper.Map<TDto>(entity);
            result.Success = true;
            return result;
        }

        public bool Delete(TPrimaryKey primaryKey)
        {
            return Repository.Delete(primaryKey);
        }

        #endregion
    }
}