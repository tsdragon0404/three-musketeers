using System;

namespace SMS.Common.CustomAttributes
{
    public sealed class PageIDAttribute : Attribute
    {
        public long PageID { get; private set; }

        public PageIDAttribute(long pageID)
        {
            PageID = pageID;
        }
    }
}