using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceTableService
    {
        IList<InvoiceTableDto> GetAllInvoiceTables();
        IList<InvoiceTableDto> GetTablesAreaID(long areaID);
        long AddNewInvoiceTable(long tableID);
    }
}