using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

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

        public bool SaveArea(AreaDto areaDto)
        {
            var area = Mapper.Map<Area>(areaDto);
            if(area.ID == 0)
                AreaRepository.Add(area);
            else
            {
                var mergeArea = AreaRepository.Merge(area);
                AreaRepository.Update(mergeArea);
            }
            return true;
        }

        public bool DeleteArea(long areaID)
        {
            AreaRepository.Delete(areaID);
            return true;
        }
    }
}