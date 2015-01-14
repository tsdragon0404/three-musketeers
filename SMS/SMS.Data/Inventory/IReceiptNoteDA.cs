using System.Collections.Generic;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface IReceiptNoteDA : IEntityDA<ReceiptNote>
    {
        List<ReceiptNote> ListAll();
    }
}