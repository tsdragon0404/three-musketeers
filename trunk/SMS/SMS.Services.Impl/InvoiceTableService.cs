using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class InvoiceTableService : IInvoiceTableService
    {
        #region Fields

        public virtual IInvoiceTableManagement InvoiceTableManagement { get; set; }

        #endregion

        public IList<InvoiceTableDto> GetAllInvoiceTables()
        {
            return InvoiceTableManagement.GetAllInvoiceTables();
        }
    }
}