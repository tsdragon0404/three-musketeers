using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class TableManagement : BaseManagement<TableDto, Table, long, ITableRepository>, ITableManagement
    {
        #region Fields

        #endregion

        #region Func

        public override Func<Table, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Area != null
                                 && x.Area.Branch != null
                                 && x.Area.Branch.ID == y;
            }
        }

        public override Func<IEnumerable<Table>, IOrderedEnumerable<Table>> ExecuteOrderFunc
        {
            get
            {
                return x => x.OrderBy(y => y.Area.SEQ).ThenBy(y => y.SEQ);
            }
        }

        #endregion
    }
}