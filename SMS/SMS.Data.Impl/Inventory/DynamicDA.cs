using System.Collections.Generic;
using System.Linq;
using Core.Data.PetaPoco;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class DynamicDA : BaseDA, IDynamicDA
    {
        public DynamicDA(IConfig config) : base(config)
        {}

        public void ExecuteNonQuery(string sql, params object[] args)
        {
            var db = new Database(config);
            db.Execute(sql, args);
        }

        public TModel Get<TModel>(string sql, params object[] args)
        {
            var db = new Database(config);
            return db.SingleOrDefault<TModel>(sql, args);
        }

        public IList<TModel> List<TModel>(string sql, params object[] args)
        {
            var db = new Database(config);
            return db.Query<TModel>(sql, args).ToList();
        }
    }
}
