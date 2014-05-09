using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class InvoiceDetailService : BaseService<InvoiceDetailDto, long, IInvoiceDetailManagement>, IInvoiceDetailService
    {
        #region Fields

        #endregion

        public InvoiceDetailDto AddProductToInvoiceTable(long invoiceTableID, long productID, int quantity)
        {
            return Management.AddProductToInvoiceTable(invoiceTableID, productID, quantity);
        }
    }
}