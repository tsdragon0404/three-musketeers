using System.Collections.Generic;
using Core.Common.Session;
using SMS.Data.Dtos;
using SMS.Data.Dtos.Models;

namespace SMS.MvcApplication.Models
{
    public class CashierModel
    {
        public IList<AreaBasicDto> ListArea { get; set; }

        public IList<ProductOrderDto> ListProduct { get; set; }

        public BranchConfigInfo BranchConfig { get; set; }
    }
}