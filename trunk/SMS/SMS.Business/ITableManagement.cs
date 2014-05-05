using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface ITableManagement : IBaseManagement<TableDto, long>
    {
        IList<TableDto> GetTablesByAreaID(long areaID);
    }
}