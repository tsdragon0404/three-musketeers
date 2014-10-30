using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
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
    }
}
