using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IAreaManagement
    {
        IList<AreaDto> GetAllAreas();
        AreaDto GetAreaByID(long areaID);
        bool SaveArea(AreaDto areaDto);
        bool DeleteArea(long areaID);
    }
}