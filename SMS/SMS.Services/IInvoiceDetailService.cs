using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceDetailService : IBaseService<InvoiceDetailDto, long>
    {
        bool AddProductToInvoiceTable(long invoiceTableID, long productID, decimal quantity);
        bool UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value);
    }
}