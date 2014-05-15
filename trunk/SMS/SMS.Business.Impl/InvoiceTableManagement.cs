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

            var b = TableRepository.Find(x => x.Area.ID == areaID && !x.InvoiceTables.Any());

            a.AddRange(b.Select(table => new InvoiceTable
            {
                ID = 0,
                Table = table,
            }));

            return Mapper.Map<IList<InvoiceTableDto>>(a.OrderBy(x => x.Table.SEQ).ToList());
        }

        public InvoiceTableDto CreateInvoiceTable(long tableID)
        {
            var invoiceTable = new InvoiceTable { Table = new Table { ID = tableID } };
            Repository.Add(invoiceTable);

            return Mapper.Map<InvoiceTableDto>(invoiceTable);
        }

        public InvoiceTableDto GetTableDetail(long invTblID)
        {
            var result = Repository.Get(invTblID);
            return result == null ? null : Mapper.Map<InvoiceTableDto>(result);
        }

        public void UpdateTableDetail(long invTblID)
        {
            var total = InvoiceDetailRepository.Find(x => x.InvoiceTable.ID == invTblID).Sum(x => x.Price*x.Quantity);
            var invoiceTable = Repository.Get(invTblID);

            invoiceTable.TableAmount = total;
            
            Repository.Update(invoiceTable);
        }

        public bool CheckTableStatus(long tableID)
        {
            var result = Repository.Find(x => x.Table.ID == tableID && x.Invoice == null);
            return result.Any();
        }
    }


}