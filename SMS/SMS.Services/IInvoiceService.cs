using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IInvoiceService
    {
        IList<InvoiceDto> GetAllInvoices();
    }
}