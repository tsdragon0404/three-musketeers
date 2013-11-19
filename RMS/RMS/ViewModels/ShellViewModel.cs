using Caliburn.Micro;
using TM.Utilities;

namespace RMS.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        #region Public Properties

        //public AdminHomeViewModel AdminHomeViewModel { get; set; }

        public Context Context { get; set; } 

        #endregion

        public ShellViewModel()
        {
            DisplayName = "RMS";
        }

        public void ActivateModule(IScreen viewModel)
        {
            if (viewModel != null && ActiveItem != null && viewModel.GetType() == ActiveItem.GetType())
                return;

            ActivateItem(viewModel);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            //ActivateModule(AdminHomeViewModel);
        }
    }
}
