using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class CashierModel
    {
        public IList<LanguageAreaDto> ListArea { get; set; }

        public IList<SearchProductDto> ListProduct { get; set; }
    }
}