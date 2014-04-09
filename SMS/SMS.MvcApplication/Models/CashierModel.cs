using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class CashierModel
    {
        public IList<TableDto> ListTable { get; set; }
    }
}