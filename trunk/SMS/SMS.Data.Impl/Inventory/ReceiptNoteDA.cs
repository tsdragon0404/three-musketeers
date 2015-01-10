﻿using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class ReceiptNoteDA : EntityDA<ReceiptNote>, IReceiptNoteDA
    {
        public ReceiptNoteDA(IConfig config) : base(config)
        {
        }
    }
}