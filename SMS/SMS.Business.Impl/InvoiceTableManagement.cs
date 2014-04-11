using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class InvoiceTableManagement : IInvoiceTableManagement
    {
        #region Fields

        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }

        #endregion

        public IList<InvoiceTableDto> GetAllInvoiceTables()
        {
            return Mapper.Map<IList<InvoiceTableDto>>(InvoiceTableRepository.GetAll().ToList());
        }
    }
}