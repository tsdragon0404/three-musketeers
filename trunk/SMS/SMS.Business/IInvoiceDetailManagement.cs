using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceDetailManagement : IBaseManagement<InvoiceDetailDto, long>
    {
        bool AddProductToInvoiceTable(long invoiceTableID, long productID, decimal quantity);
        bool UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value);
    }
}