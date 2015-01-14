using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Data.Impl.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.UnitTesting
{
    [TestClass]
    public class ReceiptNoteDATest : BaseDataTest
    {
        private IReceiptNoteDA da;
        private IDynamicDA dynamicDA;

        [TestInitialize]
        public void Initialize()
        {
            da = new ReceiptNoteDA(config);
            dynamicDA = new DynamicDA(config);
        }

        [TestCleanup]
        public void CleanUp()
        {
            dynamicDA.ExecuteNonQuery("DELETE ReceiptNote");
        }

    }
}
