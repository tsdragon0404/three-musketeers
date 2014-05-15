using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceTableService : IBaseService<InvoiceTableDto, long>
    {
        IList<InvoiceTableDto> GetTablesAreaID(long areaID);
        InvoiceTableDto CreateInvoiceTable(long tableID);
        InvoiceTableDto GetTableDetail(long invTblID);

        bool CheckTableStatus(long tableID);
    }
}