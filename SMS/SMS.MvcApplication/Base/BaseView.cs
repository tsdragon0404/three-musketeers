using System.Collections.Generic;
using System.Web.Mvc;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseView<T> : WebViewPage<T>
    {
        protected Dictionary<string, string> LabelDictionary
        {
            get { return ViewData[Common.Constant.ConstConfig.PageLabelKey] as Dictionary<string, string>; }
        }

        protected long? PageID
        {
            get { return (long?)ViewData[Common.Constant.ConstConfig.PageIDKey]; }
        }

        protected List<LanguagePageDto> AccessiblePagesForUser
        {
            get { return ViewData[Common.Constant.ConstConfig.AccessiblePagesForUserKey] as List<LanguagePageDto>; }
        }

        protected List<PageMenuDto> PageMenus
        {
            get { return ViewData[Common.Constant.ConstConfig.PageMenuKey] as List<PageMenuDto>; }
        }
    }

    public abstract class BaseView : BaseView<object>
    {
        
    }
}