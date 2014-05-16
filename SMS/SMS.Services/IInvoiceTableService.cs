using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceTableService : IBaseService<InvoiceTableDto, long>
    {
        IList<TDto> GetTablesByAreaID<TDto>(long areaID);
        long CreateInvoiceTable(long tableID);
        TDto GetTableDetail<TDto>(long invTblID);

        bool CheckTableStatus(long tableID);
    }
}