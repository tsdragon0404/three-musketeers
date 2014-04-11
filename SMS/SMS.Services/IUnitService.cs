using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IUnitService
    {
        IList<UnitDto> GetAllUnits();
    }
}