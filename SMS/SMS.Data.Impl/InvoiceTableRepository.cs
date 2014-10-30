using System;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class InvoiceTableRepository : BaseRepository<InvoiceTable>, IInvoiceTableRepository
    {
        #region Func

        public override Func<InvoiceTable, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Invoice != null
                                 && x.Invoice.Branch != null
                                 && x.Invoice.Branch.ID == y;
            }
        }

        #endregion
    }
}
