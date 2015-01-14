using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class ReceiptNoteDA : EntityDA<ReceiptNote>, IReceiptNoteDA
    {
        public ReceiptNoteDA(IConfig config, SqlStatementDA sqlStatementDA) : base(config, sqlStatementDA)
        {
        }

        public List<ReceiptNote> ListAll()
        {
            return DAHelper.Select<ReceiptNote>(config, SqlStatement.ReceiptNote_ListAll);
        }
    }
}