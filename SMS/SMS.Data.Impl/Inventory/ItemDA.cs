using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class ItemDA : EntityDA, IItemDA
    {
        public ItemDA(IConfig config, ISqlStatementDA sqlStatementDA)
            : base(config, sqlStatementDA)
        {
        }

        public List<Item> GetList(bool isEnable = true)
        {
            return DAHelper.Select<Item>(config, "SELECT * FROM ITEM WHERE ENABLE=@0", isEnable.ToSqlValue());
        }

        public Item GetByID(long itemID)
        {
            return DAHelper.SelectOne<Item>(config, "SELECT * FROM ITEM WHERE ID=@0", itemID);
        }

        public Item Update(Item item, params string[] columns)
        {
            return DAHelper.Update(config, item, columns);
        }

        public Item Insert(Item item)
        {
            return DAHelper.Insert(config, item);
        }

        public bool Delete(long itemID)
        {
            return DAHelper.Delete<Item>(config, itemID);
        }
    }
}