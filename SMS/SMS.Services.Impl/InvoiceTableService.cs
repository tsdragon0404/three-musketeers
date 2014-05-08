using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class InvoiceTableService : BaseService<InvoiceTableDto, long, IInvoiceTableManagement>, IInvoiceTableService
    {
        #region Fields

        #endregion

        public IList<InvoiceTableDto> GetTablesAreaID(long areaID)
        {
            return Management.GetTablesAreaID(areaID);
        }

        public long CreateInvoiceTable(long tableID)
        {
            return Management.CreateInvoiceTable(tableID);
        }

        public InvoiceTableDto GetTableDetail(long invTblID)
        {
            return Management.GetTableDetail(invTblID);
        }
    }
}