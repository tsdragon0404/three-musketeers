﻿using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("CURRENCY")]
    [PrimaryKey("ID")]
    public class Currency
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Exchange { get; set; }
        public bool Enable { get; set; }
        public int SEQ { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
