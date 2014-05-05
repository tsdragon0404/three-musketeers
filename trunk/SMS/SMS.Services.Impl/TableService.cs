using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class TableService : BaseService<TableDto, long, ITableManagement>, ITableService
    {
        #region Fields

        #endregion

        public IList<TableDto> GetTablesByAreaID(long areaID)
        {
            return Management.GetTablesByAreaID(areaID);
        }
    }
}