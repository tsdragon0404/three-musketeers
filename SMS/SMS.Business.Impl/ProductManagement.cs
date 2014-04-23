using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Core.Common;
using SMS.Data;
using AutoMapper;
using SMS.Data.Dtos;

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

        public IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            var invoiceTable = InvoiceTableRepository.Get(invoiceTableID);
            var productCodes = invoiceTable.InvoiceDetails.Select(x => x.ProductCode).ToList();
            
            var products = ProductRepository.Find(x => productCodes.Contains(x.ProductCode));
            var returnValue = Mapper.Map<IList<ProductBasicDto>>(products.ToList());

            returnValue.Apply(x => x.Quantity =
                invoiceTable.InvoiceDetails.FirstOrDefault(y => y.ProductCode == x.ProductCode) == null
                    ? 0
                    : invoiceTable.InvoiceDetails.First(y => y.ProductCode == x.ProductCode).Quantity);

            return returnValue;
        }
    }
}