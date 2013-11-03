using System.Collections.Generic;
using System.Data;
using System.Linq;
using RMS.Core.Entities;
using RMS.Data.Interfaces;
using TM.Data;

namespace RMS.Data
{
    public class CategoryDataService : DataServiceBase, ICategoryDataService 
    {
        public IList<ProductCategory> GetAll()
        {
            return new List<ProductCategory>();
        }

        public void DoTransaction()
        {
            var p = new SprocParameters();
            p.AddParam("param1", "value", SqlDbType.NVarChar);
            p.AddParam("param2", 5, SqlDbType.Int, ParameterDirection.Output);

            var categoryDataset = ExecuteDataSet("sp_bbb", p);
            var category = categoryDataset.Tables[0].Map<ProductCategory>().ToList();
        }

    }
}
