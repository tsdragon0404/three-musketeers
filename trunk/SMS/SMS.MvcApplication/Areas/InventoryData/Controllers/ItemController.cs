using System.Linq;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.Data.Dtos.Inventory;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;
using SMS.Services.Inventory;

namespace SMS.MvcApplication.Areas.InventoryData.Controllers
{
    [SmsAuthorize(ConstPage.InventoryData_Item)]
    [PageID(ConstPage.InventoryData_Item)]
    public class ItemController : BaseController
    {
        #region Fields

        public virtual IItemService Service { get; set; }
        public virtual Services.Inventory.IProductCategoryService ProductCategoryService { get; set; }
        public virtual IUnitService UnitService { get; set; }

        #endregion

        [HttpGet]
        public virtual ActionResult Index()
        {
            ViewBag.CategoryDictionary = ProductCategoryService.GetListForInventory<LanguageProductCategoryDto>()
                .ToDictionary(x => x.ID, x => x.Name);
            ViewBag.UnitDictionary = UnitService.ListItemUnit<LanguageUnitDto>()
                .ToDictionary(x => x.ID, x => x.Name);

            var recordList = Service.GetList();

            var model = new AdminModel<ItemDto>
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
            return Json(JsonModel.Create(new ItemDto()));
        }

        [HttpPost]
        public virtual JsonResult SaveData(ItemDto data)
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
