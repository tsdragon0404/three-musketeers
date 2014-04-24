using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class AreaManagement : IAreaManagement
    {
        #region Fields

        public virtual IAreaRepository AreaRepository { get; set; }

        #endregion

        public IList<AreaDto> GetAllAreas()
        {
            return Mapper.Map<IList<AreaDto>>(AreaRepository.GetAll().ToList());
        }

        public AreaDto GetAreaByID(long areaID)
        {
            return Mapper.Map<AreaDto>(AreaRepository.Get(areaID));
        }
    }
}