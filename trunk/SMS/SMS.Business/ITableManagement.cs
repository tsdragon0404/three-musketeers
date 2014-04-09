using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface ITableManagement
    {
        IList<TableDto> GetAllTables();
    }
}