using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceDetailManagement : BaseManagement<InvoiceDetailDto, InvoiceDetail, long, IInvoiceDetailRepository>, IInvoiceDetailManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }
        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }
        public virtual IInvoiceTableManagement InvoiceTableManagement { get; set; }

        #endregion

        public bool AddProductToInvoiceTable(long invoiceTableID, long productID, decimal quantity)
        {
            var product = ProductRepository.Get(productID);
            if(product == null)
                return false;
            var invoiceDetail = new InvoiceDetail
                                    {
                                        InvoiceTable = new InvoiceTable {ID = invoiceTableID},
                                        Quantity = quantity,
                                        ProductCode = product.ProductCode,
                                        ProductVNName = product.VNName,
                                        ProductENName = product.ENName,
                                        Price = product.Price,
                                        UnitVNName = product.Unit.VNName,
                                        UnitENName = product.Unit.ENName
                                    };
            Repository.Add(invoiceDetail);
            InvoiceTableManagement.UpdateTableDetail(invoiceDetail.InvoiceTable.ID);
            return true;
        }

        public bool UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value)
        {
            var invoiceDetail = Repository.Get(invoiceDetailID);
            if (invoiceDetail == null)
                return false;
            switch (columnName)
            {
                case "qty":
                    invoiceDetail.Quantity = decimal.Parse(value);
                    break;
                case "cmt":
                    invoiceDetail.Comment = value;
                    break;
            }
            Repository.Update(invoiceDetail);
            InvoiceTableManagement.UpdateTableDetail(invoiceDetail.InvoiceTable.ID);

            return true;
        }
    }
}