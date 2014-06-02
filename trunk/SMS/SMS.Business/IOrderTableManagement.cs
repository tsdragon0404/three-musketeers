using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderTableManagement : IBaseManagement<OrderTableDto, long>
    {
        IList<TDto> GetTablesByAreaID<TDto>(long areaID);
        long CreateOrderTable(long tableID);
        bool CheckTableStatus(long tableID);
    }
}