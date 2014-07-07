using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SMS.Data.Dtos;
using Core.Common;
using SMS.MvcApplication.Models;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseView<T> : WebViewPage<T>
    {
        private const string LISTID = "{{LISTID}}";
        private const string LISTCLASS = "{{LISTCLASS}}";
        private const string LISTITEMCLASS = "{{LISTITEMCLASS}}";
        private const string SELECTEDLISTITEMCLASS = "{{SELECTEDLISTITEMCLASS}}";
        private const string HYPERLINKCLASS = "{{HYPERLINKCLASS}}";

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

        protected string BuildMenuList(string groupName, BuildMenuOption option = null)
        {
            if (PageMenus == null || !PageMenus.Any() || AccessiblePagesForUser == null || !AccessiblePagesForUser.Any())
                return string.Empty;

            string menu = string.Format("<ul{0}{1}>", LISTID, LISTCLASS);

            foreach (var pageMenu in PageMenus.Where(x => x.GroupName == groupName))
            {
                var page = AccessiblePagesForUser.FirstOrDefault(x => x.ID == pageMenu.PageID);
                if (page == null) { continue; }

                var listItemClass = LISTITEMCLASS;
                if (option != null && !option.SelectedListItemClass.IsNullOrEmpty() && option.CurrentControllerName == page.Controller)
                    listItemClass += SELECTEDLISTITEMCLASS;

                if (page.Area.IsNullOrEmpty() && page.Controller.IsNullOrEmpty())
                    menu += string.Format("<li{0}><a{1} href=\"{2}\">{2}</a>", listItemClass, HYPERLINKCLASS, page.Title);
                else
                    menu += string.Format("<li{0}><a{1} href=\"{2}\">{3}</a>", listItemClass, HYPERLINKCLASS, 
                        Url.Action(page.Action, page.Controller, new { area = page.Area }), page.Title);

                menu += "</li>";
            }

            menu += "</ul>";

            return MergeMenuWithOption(menu, option);
        }

        private string MergeMenuWithOption(string menu, BuildMenuOption option)
        {
            if (option == null)
                return menu.Replace(LISTID, "").Replace(LISTCLASS, "").Replace(LISTITEMCLASS, "").Replace(HYPERLINKCLASS, "");

            var mergeMenu = menu;
            mergeMenu = mergeMenu.Replace(LISTID, !option.ListId.IsNullOrEmpty() ? string.Format(" id=\"{0}\"", option.ListId) : "");
            mergeMenu = mergeMenu.Replace(LISTCLASS, !option.ListClass.IsNullOrEmpty() ? string.Format(" class=\"{0}\"", option.ListClass) : "");
            mergeMenu = mergeMenu.Replace(LISTITEMCLASS + SELECTEDLISTITEMCLASS, string.Format(" class=\"{0} {1}\"", option.ListItemClass, option.SelectedListItemClass));
            mergeMenu = mergeMenu.Replace(LISTITEMCLASS, !option.ListItemClass.IsNullOrEmpty() ? string.Format(" class=\"{0}\"", option.ListItemClass) : "");
            mergeMenu = mergeMenu.Replace(HYPERLINKCLASS, !option.HyperLinkClass.IsNullOrEmpty() ? string.Format(" class=\"{0}\"", option.HyperLinkClass) : "");

            return mergeMenu;
        }
    }

    public abstract class BaseView : BaseView<object>
    {
        
    }
}