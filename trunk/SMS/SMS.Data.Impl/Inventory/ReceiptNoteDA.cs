using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class ReceiptNoteDA : BaseDA<ReceiptNote>, IReceiptNoteDA
    {
        public ReceiptNoteDA(IConfig config) : base(config)
        {
        }
    }
}