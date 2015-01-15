﻿using Core.Data.PetaPoco;

namespace SMS.Data.Entities.Inventory
{
    [TableName("SQLSTATEMENT")]
    [PrimaryKey("NAME")]
    public class SqlStatement
    {
        public string Name { get; set; }
        public string QueryString { get; set; }
    }
}