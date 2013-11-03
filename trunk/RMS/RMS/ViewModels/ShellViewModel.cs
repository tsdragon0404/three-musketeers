using Caliburn.Micro;
using RMS.Admin.ViewModels;

namespace RMS.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        public ProductCategoryViewModel ProductCategoryViewModel { get; set; }

        public bool CanClick
        {
            get { return true; }
        }

        public void Click()
        {
            //if(ProductCategoryViewModel == null)
               
            ActivateItem(ProductCategoryViewModel);
        }

        public ShellViewModel()
        {
            DisplayName = "RMS";
        }
    }
}
