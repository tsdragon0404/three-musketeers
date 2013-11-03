using System.Collections.Generic;
using RMS.Core.Entities;

namespace RMS.Data.Interfaces
{
    public interface ICategoryDataService
    {
        IList<ProductCategory> GetAll();
        void DoTransaction();
    }
}
