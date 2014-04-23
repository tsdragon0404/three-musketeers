using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductManagement : IProductManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }
        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }
        public virtual IInvoiceDetailRepository InvoiceDetailRepository { get; set; }

        #endregion

        public IList<TProductDto> GetAllProducts<TProductDto>()
        {
            return Mapper.Map<IList<TProductDto>>(ProductRepository.GetAll().ToList());
        }

        public TProductDto GetProductByID<TProductDto>(long id)
        {
            return Mapper.Map<TProductDto>(ProductRepository.Get(id));
        }

        public IList<TProductDto> GetProductsOrderingByInvoiceTableID<TProductDto>(long invoiceTableID)
        {
            var invoiceTable = InvoiceTableRepository.Get(invoiceTableID);
            var productCodes = invoiceTable.InvoiceDetails.Select(x => x.ProductCode).ToList();

            var products = ProductRepository.Find(x => productCodes.Contains(x.ProductCode));
            return Mapper.Map<IList<TProductDto>>(products.ToList());
        }
    }
}