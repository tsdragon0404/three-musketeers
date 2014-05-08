using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceTableManagement : IBaseManagement<InvoiceTableDto, long>
    {
        IList<InvoiceTableDto> GetTablesAreaID(long areaID);
        InvoiceTableDto CreateInvoiceTable(long tableID);
        InvoiceTableDto GetTableDetail(long invTblID);
    }
}