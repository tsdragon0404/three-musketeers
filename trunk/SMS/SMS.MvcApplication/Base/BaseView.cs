using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SMS.Data.Dtos;
using Core.Common;
using SMS.MvcApplication.Models;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseView<T> : WebViewPage<T>
    {
        private const string SUBLISTCLASS = "{{SUBLISTCLASS}}";
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

        protected IList<LanguagePageDto> AccessiblePagesForUser
        {
            get { return ViewData[Common.Constant.ConstConfig.AccessiblePagesForUserKey] as IList<LanguagePageDto>; }
        }

        protected IList<PageMenuDto> PageMenus
        {
            get { return ViewData[Common.Constant.ConstConfig.PageMenuKey] as IList<PageMenuDto>; }
        }

        protected string BuildMenuList(string groupName, BuildMenuOption option = null)
        {
            if (PageMenus == null || !PageMenus.Any() || AccessiblePagesForUser == null || !AccessiblePagesForUser.Any())
                return string.Empty;

            var menu = "";

            menu = PageMenus.Where(x => x.GroupName == groupName && x.ParentID == 0).Aggregate(menu, (current, pageMenu) => current + BuildMenuItem(pageMenu, option));

            return MergeMenuWithOption(menu, option);
        }

        private string BuildMenuItem(PageMenuDto pageMenu, BuildMenuOption option = null)
        {
            var menuItem = "";
            var page = AccessiblePagesForUser.FirstOrDefault(x => x.ID == pageMenu.PageID);
            if (page == null) { return menuItem; }

            var listItemClass = LISTITEMCLASS;
            if (option != null && !option.SelectedListItemClass.IsNullOrEmpty() && option.CurrentControllerName == page.Controller)
                listItemClass += SELECTEDLISTITEMCLASS;
            
            if (page.Area.IsNullOrEmpty() && page.Controller.IsNullOrEmpty())
                menuItem += string.Format("<li{0}><a{1} href=\"{2}\">{2}</a>", listItemClass, HYPERLINKCLASS, page.Title);
            else
                menuItem += string.Format("<li{0}><a{1} href=\"{2}\">{3}</a>", listItemClass, HYPERLINKCLASS,
                    Url.Action(page.Action, page.Controller, new { area = page.Area }), page.Title);

            if (PageMenus.Any(x => x.ParentID == pageMenu.ID && x.ID != pageMenu.ID))
            {
                menuItem += string.Format("<ul{0}>", SUBLISTCLASS);

                var subMenuItems = PageMenus.Where(x => x.ParentID == pageMenu.ID && x.ID != pageMenu.ID);
                menuItem = subMenuItems.Aggregate(menuItem, (current, item) => current + BuildMenuItem(item, option));

                menuItem += "</ul>";
            }

            menuItem += "</li>";

            return menuItem;
        }

        private string MergeMenuWithOption(string menu, BuildMenuOption option)
        {
            if (option == null)
                return menu.Replace(LISTITEMCLASS, "").Replace(HYPERLINKCLASS, "");

            var mergeMenu = menu;
            mergeMenu = mergeMenu.Replace(SUBLISTCLASS, !option.SubListClass.IsNullOrEmpty() ? string.Format(" class=\"{0}\"", option.SubListClass) : "");
            mergeMenu = mergeMenu.Replace(LISTITEMCLASS + SELECTEDLISTITEMCLASS, string.Format(" class=\"{0} {1}\"", option.ListItemClass, option.SelectedListItemClass));
            mergeMenu = mergeMenu.Replace(LISTITEMCLASS, !option.ListItemClass.IsNullOrEmpty() ? string.Format(" class=\"{0}\"", option.ListItemClass) : "");
            mergeMenu = mergeMenu.Replace(HYPERLINKCLASS, !option.HyperLinkClass.IsNullOrEmpty() ? string.Format(" class=\"{0}\"", option.HyperLinkClass) : "");

            return mergeMenu;
        }

        protected string JsonEncode(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
                                                                         {
                                                                             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                                         });
        }
    }

    public abstract class BaseView : BaseView<object>
    {
        
    }
}