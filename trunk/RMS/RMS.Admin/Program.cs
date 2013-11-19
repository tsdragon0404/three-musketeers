using System;
using System.Windows.Forms;
using RMS.Autofac;
using Autofac;
using TM.UI.WindowsForms;
using TM.Utilities;

namespace RMS.Admin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException; 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            var container = builder.Install().InstallWindowsForms().Build();

            var frm = container.Resolve<frmMain>();
            Application.Run(frm);
        }
    }
}
