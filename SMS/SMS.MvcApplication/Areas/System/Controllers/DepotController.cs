using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.Data.Dtos.Inventory;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;
using SMS.Services.Inventory;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_SetupDepot)]
    [PageID(ConstPage.System_SetupDepot)]
    public class DepotController : BaseController
    {
        #region Fields

        public virtual IDepotService Service { get; set; }

        #endregion

        public ActionResult Index()
        {
            var recordList = Service.ListDepot();

            var model = new AdminModel<DepotDto>
            {
                ListRecord = recordList,
                CanAdd = true,
                CanDelete = true,
                CanEdit = true
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult GetDataForEdit(long recordID)
        {
            return Json(JsonModel.Create(Service.GetByID(recordID)));
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            return Json(JsonModel.Create(new DepotDto()));
        }

        [HttpPost]
        public virtual JsonResult SaveData(DepotDto data)
        {
            return Json(JsonModel.Create(Service.Save(data)));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(long recordID)
        {
            return Json(JsonModel.Create(Service.Delete(recordID)));
        }
    }
}
