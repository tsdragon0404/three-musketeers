using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IAreaService
    {
        IList<AreaDto> GetAllAreas();
    }
}