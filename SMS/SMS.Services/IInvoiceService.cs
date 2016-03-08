using SMS.Data.Dtos;
using System;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IInvoiceService : IBaseService<InvoiceDto, long>
    {
        IList<InvoiceDto> SearchInvoice(DateTime? fromDate, DateTime? toDate, int? minAmount, int? maxAmount, string customerName);
    }
}