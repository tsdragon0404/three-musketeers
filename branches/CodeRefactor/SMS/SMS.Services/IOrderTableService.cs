using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IOrderTableService : IBaseService<OrderTableDto>
    {
        ServiceResult<IList<TDto>> GetTablesByAreaID<TDto>(long areaID);
        ServiceResult<long> CreateOrderTable(long tableID);
        ServiceResult CheckTableStatus(long tableID);
        ServiceResult<long> CreateMultiOrderTable(long[] table);
        ServiceResult<TDto> MoveTable<TDto>(long orderTableID, long tableID);
        ServiceResult PoolingTable(long[] orderTable);
        ServiceResult SendToKitchen(long orderTableID);
    }
}