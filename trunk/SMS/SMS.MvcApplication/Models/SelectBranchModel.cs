using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class SelectBranchModel
    {
        public long SelectedBranchID { get; set; }
        public IList<LanguageBranchBasicDto> Branches { get; set; }
    }
}