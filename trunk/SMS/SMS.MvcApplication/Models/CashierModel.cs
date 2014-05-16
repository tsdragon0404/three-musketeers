﻿using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class CashierModel
    {
        public IList<CashierAreaDto> ListArea { get; set; }

        public IList<CashierProductDto> ListProduct { get; set; }
    }
}