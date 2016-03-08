using System;
using System.Collections.Generic;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using System.Linq;

namespace SMS.Business.Impl
{
    public class InvoiceManagement : BaseManagement<InvoiceDto, Invoice, long, IInvoiceRepository>, IInvoiceManagement
    {
        #region Fields

        #endregion


        public IList<InvoiceDto> SearchInvoice(DateTime? fromDate, DateTime? toDate, int? minAmount, int? maxAmount, string customerName)
        {
            var query = Repository.GetQuery();
            if (!string.IsNullOrEmpty(customerName))
                query = query.Where(x => x.CustomerName.Contains(customerName));
            if (fromDate.HasValue)
                query = query.Where(x => x.InvoiceDate.Date >= fromDate.Value.Date);
            if (toDate.HasValue)
                query = query.Where(x => x.InvoiceDate.Date <= toDate.Value.Date);

            var list = query.ToList();
            var dtoList = AutoMapper.Mapper.Map<List<InvoiceDto>>(list);
            dtoList.RemoveAll(x => (minAmount.HasValue && minAmount.Value > x.Total)
                                || (maxAmount.HasValue && maxAmount.Value < x.Total));

            return dtoList;
        }
    }
}