using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceTableService : IBaseService<InvoiceTableDto, long>
    {
        IList<InvoiceTableDto> GetTablesAreaID(long areaID);
        long CreateInvoiceTable(long tableID);
        InvoiceTableDto GetTableDetail(long invTblID);

    }
}