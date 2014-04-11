using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class InvoiceService : IInvoiceService
    {
        #region Fields

        public virtual IInvoiceManagement InvoiceManagement { get; set; }

        #endregion

        public IList<InvoiceDto> GetAllInvoices()
        {
            return InvoiceManagement.GetAllInvoices();
        }
    }
}