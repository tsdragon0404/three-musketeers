using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UnitService : BaseService<UnitDto, IUnitManagement>, IUnitService
    {
        #region Fields

        #endregion

        public List<TModel> ListItemUnit<TModel>()
        {
            return Management.ListItemUnit<TModel>();
        }
    }
}