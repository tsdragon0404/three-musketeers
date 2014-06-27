using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using AutoMapper;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class ProductManagement : BaseManagement<ProductDto, Product, long, IProductRepository>, IProductManagement
    {
        #region Fields

        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }

        #endregion

        public IList<LanguageProductDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            var invoiceTable = InvoiceTableRepository.Get(invoiceTableID);
            var productCodes = invoiceTable.InvoiceDetails.Select(x => x.ProductCode).ToList();
            
            var products = Repository.Find(x => productCodes.Contains(x.ProductCode));
            var returnValue = Mapper.Map<IList<LanguageProductDto>>(products.ToList());

            returnValue.Apply(x => x.Quantity =
                invoiceTable.InvoiceDetails.FirstOrDefault(y => y.ProductCode == x.ProductCode) == null
                    ? 0
                    : invoiceTable.InvoiceDetails.First(y => y.ProductCode == x.ProductCode).Quantity);

            return returnValue;
        }

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            var result =
                Repository.Find(x => x.ProductCategory.BranchID == SmsSystem.UserContext.BranchID && x.Enable).OrderBy(
                    x => x.ProductCategory.SEQ).ThenBy(x => x.SEQ).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(!result.Any() ? null : Mapper.Map<IList<TDto>>(result));
        }
    }
}