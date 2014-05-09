using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceDetailService : IBaseService<InvoiceDetailDto, long>
    {
        InvoiceDetailDto AddProductToInvoiceTable(long invoiceTableID, long productID, int quantity);
        InvoiceDetailDto UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value);
    }
}