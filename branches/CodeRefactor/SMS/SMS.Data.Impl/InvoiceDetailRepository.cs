using System;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class InvoiceDetailRepository : BaseRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        #region Func

        public override Func<InvoiceDetail, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.InvoiceTable != null
                                 && x.InvoiceTable.Invoice != null
                                 && x.InvoiceTable.Invoice.Branch != null
                                 && x.InvoiceTable.Invoice.Branch.ID == y;
            }
        }

        #endregion
    }
}
