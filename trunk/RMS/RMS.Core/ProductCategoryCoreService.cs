using RMS.Core.Interfaces;
using RMS.Data.Interfaces;

namespace RMS.Core
{
    public class ProductCategoryCoreService : IProductCategoryCoreService
    {
        public IProductCategoryDataService ProductCategoryDataService { get; set; }

    }
}