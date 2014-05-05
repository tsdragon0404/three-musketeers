using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceTableManagement : BaseManagement<InvoiceTableDto, InvoiceTable, long, IInvoiceTableRepository>, IInvoiceTableManagement
    {
        #region Fields

        public virtual ITableRepository TableRepository { get; set; }
        public virtual IInvoiceDetailRepository InvoiceDetailRepository { get; set; }

        #endregion

        public IList<InvoiceTableDto> GetTablesAreaID(long areaID)
        {
            var a = Repository.Find(x => x.Invoice == null && x.Table.Area.ID == areaID && x.Table.Enable).ToList();

            var b = TableRepository.Find(x => x.Area.ID == areaID && x.InvoiceTables.LongCount() == 0);

            a.AddRange(b.Select(table => new InvoiceTable
            {
                ID = 0,
                Table = table,
            }));

            return Mapper.Map<IList<InvoiceTableDto>>(a.ToList().OrderBy(x => x.Table.SEQ));
        }

        public long CreateInvoiceTable(long tableID)
        {
            var table = TableRepository.Get(tableID);

            var invoiceTable = new InvoiceTable { Table = table };
            Repository.Add(invoiceTable);

            return invoiceTable.ID;
        }
    }


}