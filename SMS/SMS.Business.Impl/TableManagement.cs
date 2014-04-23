using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class TableManagement : ITableManagement
    {
        #region Fields

        public virtual ITableRepository TableRepository { get; set; }

        #endregion

        public IList<TableDto> GetAllTables()
        {
            return Mapper.Map<IList<TableDto>>(TableRepository.GetAll().ToList());
        }

        public IList<TableDto> GetTablesByAreaID(long areaID)
        {
            return Mapper.Map<IList<TableDto>>(TableRepository.Find(x=>x.Area.ID == areaID).ToList());
        }
    }
}