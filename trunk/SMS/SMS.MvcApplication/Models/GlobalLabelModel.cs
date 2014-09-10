using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class GlobalLabelModel
    {
        public IList<PageLabelDto> PageLabels { get; set; }
    }
}