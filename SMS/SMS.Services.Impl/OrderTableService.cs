using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderTableService : BaseService<OrderTableDto, long, IOrderTableManagement>, IOrderTableService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetTablesByAreaID<TDto>(long areaID)
        {
            return Management.GetTablesByAreaID<TDto>(areaID);
        }

        public ServiceResult<long> CreateOrderTable(long tableID)
        {
            return Management.CreateOrderTable(tableID);
        }

        public ServiceResult CheckTableStatus(long tableID)
        {
            return Management.CheckTableStatus(tableID);
        }
    }
}