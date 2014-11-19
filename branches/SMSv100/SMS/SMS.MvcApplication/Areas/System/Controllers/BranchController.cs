﻿using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_Branch)]
    [PageID(ConstPage.System_Branch)]
    public class BranchController : AdminBaseController<BranchDto, long, IBranchService>
    {
        #region Fields

        public virtual ICurrencyService CurrencyService { get; set; }
        public virtual ITaxService TaxService { get; set; }
        public virtual IBranchService BranchService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListCurrency = CurrencyService.GetAll().Data;
            ViewBag.ListTax = TaxService.GetAll().Data;
            return base.Index(textSearch, page);
        }

        public override JsonResult SaveData(BranchDto branchDto)
        {
            var result = BranchService.Save(branchDto);
            return Json(JsonModel.Create(result));
        }
    }
}