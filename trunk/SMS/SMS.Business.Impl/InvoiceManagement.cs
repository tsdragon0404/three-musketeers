using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class InvoiceManagement : IInvoiceManagement
    {
        #region Fields

        public virtual IInvoiceRepository InvoiceRepository { get; set; }

        #endregion

        public IList<InvoiceDto> GetAllInvoices()
        {
            return Mapper.Map<IList<InvoiceDto>>(InvoiceRepository.GetAll().ToList());
        }
    }
}