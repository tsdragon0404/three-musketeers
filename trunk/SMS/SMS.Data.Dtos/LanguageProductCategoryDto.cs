﻿using System;

namespace SMS.Data.Dtos
{
    public class LanguageProductCategoryDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCategoryCode { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual long BranchID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}