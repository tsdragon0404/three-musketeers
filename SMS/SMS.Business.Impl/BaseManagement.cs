using System.Collections.Generic;
using System.Linq;
using Core.Data;
using AutoMapper;

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

        public TDto GetByID(TPrimaryKey ID)
        {
            return Mapper.Map<TDto>(Repository.Get(ID));
        }

        public bool Save(TDto Dto)
        {
            var entity = Mapper.Map<TEntity>(Dto);
            if (entity.ID is long && long.Parse(entity.ID.ToString()) == 0)
                Repository.Add(entity);
            else
            {
                var mergeEntity = Repository.Merge(entity);
                Repository.Update(mergeEntity);
            }
            return true;
        }

        public bool Delete(TPrimaryKey ID)
        {
            Repository.Delete(ID);
            return true;
        }

        #endregion
    }
}