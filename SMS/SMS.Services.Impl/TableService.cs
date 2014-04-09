using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class TableService : ITableService
    {
        #region Fields

        public virtual ITableManagement TableManagement { get; set; }

        #endregion

        public IList<TableDto> GetAllTables()
        {
            return TableManagement.GetAllTables();
        }
    }
}