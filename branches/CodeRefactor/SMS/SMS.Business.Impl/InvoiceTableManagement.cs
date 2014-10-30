using System;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceTableManagement : BaseManagement<InvoiceTableDto, InvoiceTable, IInvoiceTableRepository>,
                                          IInvoiceTableManagement
    {

    }
}