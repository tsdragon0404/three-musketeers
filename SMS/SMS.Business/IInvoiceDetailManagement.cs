using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceDetailManagement : IBaseManagement<InvoiceDetailDto, long>
    {
        InvoiceDetailDto AddProductToInvoiceTable(long invoiceTableID, long productID, int quantity);
        InvoiceDetailDto UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value);
    }
}