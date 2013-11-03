using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Core.Interfaces;
using TM.Data;

namespace RMS.ViewModels
{
    public class HomeViewModel
    {
        //private ICategoryCoreService CategoryCoreService;

        //public HomeViewModel(ICategoryCoreService categoryCoreService)
        //{
        //    CategoryCoreService = categoryCoreService;
        //}

        public ICategoryCoreService CategoryCoreService { get; set; }

        public void test()
        {
            CategoryCoreService.DoTransaction();
        }
    }
}
