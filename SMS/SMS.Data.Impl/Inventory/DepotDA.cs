﻿using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class DepotDA : EntityDA, IDepotDA
    {
        public DepotDA(IConfig config, ISqlStatementDA sqlStatementDA)
            : base(config, sqlStatementDA)
        {
        }

        public List<Depot> ListDepot(bool isEnable = true)
        {
            return DAHelper.Select<Depot>(config, "SELECT * FROM DEPOT WHERE ENABLE=@0", isEnable.ToSqlValue());
        }

        public Depot GetByID(long ID)
        {
            return DAHelper.SelectOne<Depot>(config, "SELECT * FROM DEPOT WHERE ID=@0", ID);
        }

        public Depot Update(Depot depot, params string[] columns)
        {
            return DAHelper.Update(config, depot, columns);
        }

        public Depot Insert(Depot depot)
        {
            return DAHelper.Insert(config, depot);
        }

        public bool Delete(long ID)
        {
            return DAHelper.Delete<Depot>(config, ID);
        }
    }
}