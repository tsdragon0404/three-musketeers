using System;
using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceManagement : IBaseManagement<InvoiceDto, long>
    {
        IList<InvoiceDto> SearchInvoice(DateTime? fromDate, DateTime? toDate, int? minAmount, int? maxAmount, string customerName);
    }
}