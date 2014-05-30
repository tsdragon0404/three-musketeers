using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderTableManagement : IBaseManagement<OrderTableDto, long>
    {
        IList<TDto> GetTablesByAreaID<TDto>(long areaID);
        long CreateOrderTable(long tableID);
        TDto GetTableDetail<TDto>(long invTblID);
        void UpdateTableDetail(long invTblID);
        bool CheckTableStatus(long tableID);
    }
}