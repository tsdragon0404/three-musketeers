using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data.Dtos;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class SearchPopupController : Controller
    {
        #region Fields

        public virtual ISearchPopupService SearchPopupService { get; set; } 

        #endregion

        [HttpGet]
        public ActionResult ProductsForCashier()
        {
            var result = SearchPopupService.ProductsForCashier();

            var jsonData = new ResultPopupModel<SearchProductPopupDto>
            {
                ListResult = result,
                TextSearch = string.Empty
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductsForCashier(string textSearch)
        {
            var result = SearchPopupService.ProductsForCashier(textSearch);

            var jsonData = new ResultPopupModel<SearchProductPopupDto>
            {
                ListResult = result,
                TextSearch = textSearch
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
