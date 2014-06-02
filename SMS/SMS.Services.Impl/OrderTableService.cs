using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderTableService : BaseService<OrderTableDto, long, IOrderTableManagement>, IOrderTableService
    {
        #region Fields

        #endregion

        public IList<TDto> GetTablesByAreaID<TDto>(long areaID)
        {
            return Management.GetTablesByAreaID<TDto>(areaID);
        }

        public long CreateOrderTable(long tableID)
        {
            return Management.CreateOrderTable(tableID);
        }

        public bool CheckTableStatus(long tableID)
        {
            return Management.CheckTableStatus(tableID);
        }
    }
}