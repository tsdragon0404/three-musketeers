using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface ITableService : IBaseService<TableDto, long>
    {
        IList<TableDto> GetTablesByAreaID(long areaID);
        IList<TableDto> GetAllTables();
    }
}