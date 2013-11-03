using Caliburn.Micro.Autofac;
using RMS.ViewModels;

namespace RMS
{
    public class RMSBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();

            EnforceNamespaceConvention = false;

            //ViewModelBaseType = typeof (IShell);
        }
    }
}
