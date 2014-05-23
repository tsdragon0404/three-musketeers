using System;
using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class LanguageInvoiceTableDto
    {
        public virtual long ID { get; set; }
        public virtual LanguageTableDto Table { get; set; }
        public virtual IList<LanguageInvoiceDetailDto> InvoiceDetails { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
