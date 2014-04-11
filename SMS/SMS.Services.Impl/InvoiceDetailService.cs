using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        #region Fields

        public virtual IInvoiceDetailManagement InvoiceDetailManagement { get; set; }

        #endregion

        public IList<InvoiceDetailDto> GetAllInvoiceDetails()
        {
            return InvoiceDetailManagement.GetAllInvoiceDetails();
        }
    }
}