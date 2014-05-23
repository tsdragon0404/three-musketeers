using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseView<T> : WebViewPage<T>
    {
        public virtual IPageLabelService PageLabelService { get; set; }

        protected Dictionary<long, string> LabelDictionary { get; set; } 

        public override void Execute()
        {
            
        }

        protected override void InitializePage()
        {
            base.InitializePage();
            LabelDictionary = PageLabelService.GetAll().ToDictionary(x => x.ID, x => x.VNText);
        }
    }
}