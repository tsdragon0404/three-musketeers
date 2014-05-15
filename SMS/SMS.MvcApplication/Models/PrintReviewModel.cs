using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class PrintReviewModel
    {
        public IList<InvoiceDetailDto> ListInvoiceDetail { get; set; } 
    }
}