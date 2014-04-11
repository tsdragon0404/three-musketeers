using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UnitService : IUnitService
    {
        #region Fields

        public virtual IUnitManagement UnitManagement { get; set; }

        #endregion

        public IList<UnitDto> GetAllUnits()
        {
            return UnitManagement.GetAllUnits();
        }
    }
}