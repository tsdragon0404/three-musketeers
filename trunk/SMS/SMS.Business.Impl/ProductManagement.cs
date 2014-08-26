using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductManagement : BaseManagement<ProductDto, Product, long, IProductRepository>, IProductManagement
    {
        #region Fields

        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }

        #endregion

        #region Func

        public override Func<Product, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.ProductCategory != null
                                 && x.ProductCategory.Branch != null
                                 && x.ProductCategory.Branch.ID == y;
            }
        }

        public override Func<IEnumerable<Product>, IOrderedEnumerable<Product>> ExecuteOrderFunc
        {
            get
            {
                return x => x.OrderBy(y => y.ProductCategory.SEQ).ThenBy(y => y.SEQ);
            }
        } 

        #endregion

        public ServiceResult<IList<LanguageProductDto>> ReloadProductList()
        {
            if (BelongToBranch == null)
                return ServiceResult<IList<LanguageProductDto>>.CreateFailResult(new Error("BelongToBranch function is not defined", ErrorType.CodeImplementation));

            var result = Repository.Find(x => x.Enable, true).Where(x => BelongToBranch(x, SmsSystem.SelectedBranchID));

            if (ExecuteOrderFunc != null)
                result = ExecuteOrderFunc(result);

            return ServiceResult<IList<LanguageProductDto>>.CreateSuccessResult(Mapper.Map<IList<LanguageProductDto>>(result));
        }
    }
}