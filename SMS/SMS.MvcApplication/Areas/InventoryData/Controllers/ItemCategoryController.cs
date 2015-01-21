using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;

namespace SMS.MvcApplication.Areas.InventoryData.Controllers
{
    [SmsAuthorize(ConstPage.InventoryData_ItemCategory)]
    [PageID(ConstPage.InventoryData_ItemCategory)]
    public class ItemCategoryController : BaseController
    {
        #region Fields

        public virtual Services.Inventory.IProductCategoryService Service { get; set; }

        #endregion

        [HttpGet]
        public virtual ActionResult Index()
        {
            var recordList = Service.GetListForInventory<Data.Dtos.Inventory.ProductCategoryDto>();

            var model = new AdminModel<Data.Dtos.Inventory.ProductCategoryDto>
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
            return Json(JsonModel.Create(Service.GetByIDForInventory(recordID)));
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            return Json(JsonModel.Create(new Data.Dtos.Inventory.ProductCategoryDto()));
        }

        [HttpPost]
        public virtual JsonResult SaveData(Data.Dtos.Inventory.ProductCategoryDto data)
        {
            return Json(JsonModel.Create(Service.SaveForInventory(data)));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(long recordID)
        {
            return Json(JsonModel.Create(Service.DeleteForInventory(recordID)));
        }
    }
}
