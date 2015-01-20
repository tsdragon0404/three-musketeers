using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IUnitManagement : IBaseManagement<UnitDto>
    {
        List<TModel> ListItemUnit<TModel>();
    }
}