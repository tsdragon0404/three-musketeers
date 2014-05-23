using System.Collections.Generic;
using System.Web.Mvc;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseView<T> : WebViewPage<T>
    {
        protected Dictionary<string, string> LabelDictionary
        {
            get { return ViewData[Common.Constant.ConstConfig.PageLabelKey] as Dictionary<string, string>; }
        } 
    }

    public abstract class BaseView : BaseView<object>
    {
        
    }
}