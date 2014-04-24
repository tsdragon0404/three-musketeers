using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceTableManagement : IInvoiceTableManagement
    {
        #region Fields

        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }
        public virtual ITableRepository TableRepository { get; set; }

        #endregion

        public IList<InvoiceTableDto> GetAllInvoiceTables()
        {
            return Mapper.Map<IList<InvoiceTableDto>>(InvoiceTableRepository.GetAll().ToList());
        }

        public IList<InvoiceTableDto> GetTablesAreaID(long areaID)
        {
            var a = InvoiceTableRepository.Find(x => x.Invoice == null && x.Table.Area.ID == areaID && x.Table.Enable).ToList();

            var b = TableRepository.Find(x => x.Area.ID == areaID && x.InvoiceTables.LongCount() == 0);

            a.AddRange(b.Select(table => new InvoiceTable
            {
                ID = 0,
                Table = table,
            }));

            return Mapper.Map<IList<InvoiceTableDto>>(a.ToList().OrderBy(x => x.Table.SEQ));
        }

        public long AddNewInvoiceTable(long tableID)
        {
            var table = TableRepository.Get(tableID);

            var entity = new InvoiceTable();
            entity.Table = table;
            InvoiceTableRepository.Add(entity);

            return entity.ID;
        }
    }


}