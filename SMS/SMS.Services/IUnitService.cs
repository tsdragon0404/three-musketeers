using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IUnitService : IBaseService<UnitDto>
    {
        List<TModel> ListItemUnit<TModel>();
    }
}