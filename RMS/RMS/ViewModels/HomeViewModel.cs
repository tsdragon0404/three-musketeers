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
        //private IProductCategoryCoreService ProductCategoryCoreService;

        //public HomeViewModel(IProductCategoryCoreService categoryCoreService)
        //{
        //    ProductCategoryCoreService = categoryCoreService;
        //}

        public IProductCategoryCoreService ProductCategoryCoreService { get; set; }

        public void test()
        {
            
        }
    }
}
