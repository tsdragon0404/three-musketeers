using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Areas.Administrator.Models
{
    public class AreaModel
    {
        public IList<AreaDto> ListArea { get; set; }
    }
}