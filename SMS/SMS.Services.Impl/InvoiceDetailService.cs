using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class InvoiceDetailService : BaseService<InvoiceDetailDto, long, IInvoiceDetailManagement>, IInvoiceDetailService
    {
        #region Fields

        #endregion

        public bool AddProductToInvoiceTable(long invoiceTableID, long productID, decimal quantity)
        {
            return Management.AddProductToInvoiceTable(invoiceTableID, productID, quantity);
        }

        public bool UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value)
        {
            return Management.UpdateProductToInvoiceTable(invoiceDetailID, columnName, value);
        }
    }
}