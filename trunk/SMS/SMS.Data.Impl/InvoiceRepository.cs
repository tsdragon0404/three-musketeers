﻿using Core.Data.NHibernate;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
    }
}