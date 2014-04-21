using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class CashierModel
    {
        public IList<AreaDto> ListArea { get; set; }

        public IList<ProductBasicDto> ListProduct { get; set; }
    }
}