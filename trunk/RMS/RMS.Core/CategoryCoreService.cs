using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;

namespace RMS.Core
{
    public class CategoryCoreService : ICategoryCoreService
    {
        public ICategoryDataService CategoryDataService { get; set; }

        public IList<ProductCategory> GetAll()
        {
            return CategoryDataService.GetAll();
        }

        public void DoTransaction()
        {
            CategoryDataService.DoTransaction();
        }
    }
}