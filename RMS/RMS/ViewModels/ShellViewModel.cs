using Caliburn.Micro;
using RMS.Admin.ViewModels;
using RMS.Core.Interfaces;
using TM.Utilities;

namespace RMS.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        public ProductCategoryViewModel ProductCategoryViewModel { get; set; }

        public ICategoryCoreService CategoryCoreService { get; set; }

        public Context Context { get; set; }

        public bool CanClick
        {
            get { return true; }
        }

        public void Click()
        {
            Context.CurUserID = 2;
            CategoryCoreService.DoTransaction();
            //ActivateItem(ProductCategoryViewModel);
        }

        public ShellViewModel()
        {
            DisplayName = "RMS";
        }
    }
}
