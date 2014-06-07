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

        public ServiceResult<long> CreateMultiOrderTable(long[] table)
        {
            return Management.CreateMultiOrderTable(table);
        }

        public ServiceResult<TDto> MoveTable<TDto>(long orderTableID, long tableID)
        {
            return Management.MoveTable<TDto>(orderTableID, tableID);
        }

        public ServiceResult PoolingTable(long[] orderTable)
        {
            return Management.PoolingTable(orderTable);
        }
    }
}