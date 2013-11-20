using Caliburn.Micro.Autofac;
using RMS.ViewModels;

namespace RMS
{
    public class RMSBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        /// <summary>
        /// Configures the bootstrapper.
        /// </summary>
        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();

            EnforceNamespaceConvention = false;

            //ViewModelBaseType = typeof (IShell);
        }
    }
}
