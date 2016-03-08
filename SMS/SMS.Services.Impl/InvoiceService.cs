using SMS.Business;
using SMS.Data.Dtos;
using System;
using System.Collections.Generic;

namespace SMS.Services.Impl
{
    public class InvoiceService : BaseService<InvoiceDto, long, IInvoiceManagement>, IInvoiceService
    {
        #region Fields

        #endregion

        public IList<InvoiceDto> SearchInvoice(DateTime? fromDate, DateTime? toDate, int? minAmount, int? maxAmount, string customerName)
        {
            return Management.SearchInvoice(fromDate, toDate, minAmount, maxAmount, customerName);
        }
    }
}