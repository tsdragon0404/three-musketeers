using System.Collections.Generic;

namespace SMS.MvcApplication.Models
{
    public class ResultPopupModel<T>
    {
        public IList<T> ListResult { get; set; }
        public string TextSearch { get; set; }
    }
}