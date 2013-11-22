﻿using System;
using System.Globalization;
using System.Windows.Forms;
using RMS.Autofac;
using Autofac;
using TM.UI.WindowsForms;

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
            Application.CurrentCulture = new CultureInfo("vi-VN");

            var builder = new ContainerBuilder();
            var container = builder.Install().InstallWindowsForms().Build();

            var frm = container.Resolve<frmMain>();
            //var frmLogin = container.Resolve<frmLoginAdmin>();
            //frmLogin.InitializeData();
            //if(frmLogin.ShowDialog() == DialogResult.OK)
                Application.Run(frm);
        }
    }
}
