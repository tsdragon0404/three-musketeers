using System;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceTableManagement : BaseManagement<InvoiceTableDto, InvoiceTable, long, IInvoiceTableRepository>,
                                          IInvoiceTableManagement
    {
        #region Func

        public override Func<InvoiceTable, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Invoice.Branch.ID == y;
            }
        }

        #endregion
    }
}