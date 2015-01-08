using Core.Data.PetaPoco;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMS.Data.Impl.UnitTesting
{
    public class BaseDataTest
    {
        protected IConfig config;

        [TestInitialize]
        public void Setup()
        {
            config = new DataTestConfig();
        }
    }

    public class DataTestConfig : IConfig
    {
        public string ConnectionString { get; set; }
        public string DbProvider { get; set; }

        public DataTestConfig()
        {
            ConnectionString = "Data Source=.;Initial Catalog=SMS_Test;User ID=sms;Password=sms";
            DbProvider = "System.Data.SqlClient";
        }
    }
}
