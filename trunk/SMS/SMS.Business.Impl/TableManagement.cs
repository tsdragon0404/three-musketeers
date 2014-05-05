using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class TableManagement : BaseManagement<TableDto, Table, long, ITableRepository>, ITableManagement
    {
        #region Fields

        #endregion

        public IList<TableDto> GetTablesByAreaID(long areaID)
        {
            return Mapper.Map<IList<TableDto>>(Repository.Find(x => x.Area.ID == areaID).ToList());
        }

        public IList<TableDto> GetAllTables()
        {
            var a = Repository.GetAll().ToList();
            foreach(var item in a)
                Repository.FetchProperties(item, x => x.Area);
            var b = Mapper.Map<IList<TableDto>>(a);
            return b;
        }
    }
}