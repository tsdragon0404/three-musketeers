using System.Collections.Generic;
using SMS.Data.Dtos;
using SMS.Data.Dtos.Models;

namespace SMS.MvcApplication.Models
{
    public class CashierModel
    {
        public IList<CashierAreaModel> ListArea { get; set; }

        public IList<ProductBasicDto> ListProduct { get; set; }
    }
}