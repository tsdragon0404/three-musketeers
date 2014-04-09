using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface ITableService
    {
        IList<TableDto> GetAllTables();
    }
}