using System;
using System.Collections.Generic;
using SMS.Data.Dtos;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public class AreaController : AdminBaseController<AreaDto, long>
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }

        protected override Func<IList<AreaDto>> GetAllFunction { get { return AreaService.GetAllAreas; } }

        protected override Func<long, AreaDto> GetDataFunction { get { return AreaService.GetAreaByID; } }

        protected override Func<AreaDto, bool> SaveDataFunction { get { return AreaService.SaveArea; } }

        protected override Func<long, bool> DeleteDataFunction { get { return AreaService.DeleteArea; } }

        #endregion
    }
}
