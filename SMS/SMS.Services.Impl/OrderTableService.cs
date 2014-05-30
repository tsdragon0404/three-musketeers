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

        public TDto GetTableDetail<TDto>(long invTblID)
        {
            return Management.GetTableDetail<TDto>(invTblID);
        }

        public bool CheckTableStatus(long tableID)
        {
            return Management.CheckTableStatus(tableID);
        }
    }
}