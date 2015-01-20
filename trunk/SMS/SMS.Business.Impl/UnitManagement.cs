using System.Collections.Generic;
using AutoMapper;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UnitManagement : BaseManagement<UnitDto, Unit, IUnitRepository>, IUnitManagement
    {
        #region Fields

        #endregion

        public List<TModel> ListItemUnit<TModel>()
        {
            var result = Repository.List(x => x.Branch == null && x.Enable);
            return Mapper.Map<List<TModel>>(result);
        }
    }
}