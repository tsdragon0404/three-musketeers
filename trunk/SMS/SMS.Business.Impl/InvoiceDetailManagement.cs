using System;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceDetailManagement : BaseManagement<InvoiceDetailDto, InvoiceDetail, long, IInvoiceDetailRepository>, IInvoiceDetailManagement
    {
        #region Fields
        #endregion

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