using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

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
                return (x, y) => x.ProductCategory.Branch.ID == y;
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
    }
}