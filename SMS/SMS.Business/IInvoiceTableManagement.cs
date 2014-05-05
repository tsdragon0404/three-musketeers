using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceTableManagement : IBaseManagement<InvoiceTableDto, long>
    {
        IList<InvoiceTableDto> GetTablesAreaID(long areaID);
        long CreateInvoiceTable(long tableID);
    }
}