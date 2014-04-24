using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceTableManagement
    {
        IList<InvoiceTableDto> GetAllInvoiceTables();
        IList<InvoiceTableDto> GetTablesAreaID(long areaID);
        long AddNewInvoiceTable(long tableID);
    }
}