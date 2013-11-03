using System.Collections.Generic;
using RMS.Core.Entities;

namespace RMS.Core.Interfaces
{
    public interface ICategoryCoreService
    {
        IList<ProductCategory> GetAll();
        void DoTransaction();
    }
}