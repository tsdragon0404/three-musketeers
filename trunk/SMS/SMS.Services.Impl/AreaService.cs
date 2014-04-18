using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class AreaService : IAreaService
    {
        #region Fields

        public virtual IAreaManagement AreaManagement { get; set; }

        #endregion

        public IList<AreaDto> GetAllAreas()
        {
            return AreaManagement.GetAllAreas();
        }
    }
}