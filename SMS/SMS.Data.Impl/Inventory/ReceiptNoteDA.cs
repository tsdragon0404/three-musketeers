using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class ReceiptNoteDA : EntityDA, IReceiptNoteDA
    {
        public ReceiptNoteDA(IConfig config, ISqlStatementDA sqlStatementDA) : base(config, sqlStatementDA)
        {
        }

        public List<ReceiptNote> ListAll()
        {
            return DAHelper.Select<ReceiptNote>(config, SqlStatement.RECEIPT_NOTE_LIST_ALL);
        }
    }
}