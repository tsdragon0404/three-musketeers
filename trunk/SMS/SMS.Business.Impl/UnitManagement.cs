using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class UnitManagement : IUnitManagement
    {
        #region Fields

        public virtual IUnitRepository UnitRepository { get; set; }

        #endregion

        public IList<UnitDto> GetAllUnits()
        {
            return Mapper.Map<IList<UnitDto>>(UnitRepository.GetAll().ToList());
        }
    }
}