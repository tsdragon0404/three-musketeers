using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IOrderTableService : IBaseService<OrderTableDto, long>
    {
        IList<TDto> GetTablesByAreaID<TDto>(long areaID);
        long CreateOrderTable(long tableID);
        bool CheckTableStatus(long tableID);
    }
}