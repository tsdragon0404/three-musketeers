using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class InvoiceDetailManagement : IInvoiceDetailManagement
    {
        #region Fields

        public virtual IInvoiceDetailRepository InvoiceDetailRepository { get; set; }

        #endregion

        public IList<InvoiceDetailDto> GetAllInvoiceDetails()
        {
            return Mapper.Map<IList<InvoiceDetailDto>>(InvoiceDetailRepository.GetAll().ToList());
        }
    }
}