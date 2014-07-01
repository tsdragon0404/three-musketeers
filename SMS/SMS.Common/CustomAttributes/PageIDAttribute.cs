using System;

namespace SMS.Common.CustomAttributes
{
    public sealed class PageIDAttribute : Attribute
    {
        public int PageID { get; private set; }

        public PageIDAttribute(int pageID)
        {
            PageID = pageID;
        }
    }
}