using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Data.Entities.Inventory;
using SMS.Data.Impl.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.UnitTesting
{
    [TestClass]
    public class ReceiptNoteDATest : BaseDataTest
    {
        private IReceiptNoteDA da;

        [TestInitialize]
        public void Initialize()
        {
            da = new ReceiptNoteDA(config);
        }

        [TestCleanup]
        public void CleanUp()
        {
            da.ExecuteCommand("DELETE ReceiptNote");
        }

        [TestMethod]
        public void ListAll_DatabaseHasData_ReturnListOfRecord()
        {
            var receiptNote1 = new ReceiptNote
                                   {
                                       BranchID = 1,
                                       ReceiptNumber = "1"
                                   };
            var receiptNote2 = new ReceiptNote
                                   {
                                       BranchID = 2,
                                       ReceiptNumber = "2"
                                   };

            da.Save(receiptNote1);
            da.Save(receiptNote2);

            var result = da.ListAll().ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result.Count(x => x.BranchID == 1 && x.ReceiptNumber == "1"));
            Assert.AreEqual(1, result.Count(x => x.BranchID == 2 && x.ReceiptNumber == "2"));
        }

        [TestMethod]
        public void ListAll_DatabaseHasNoData_ReturnEmpty()
        {
            var result = da.ListAll().ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void List_DatabaseHasData_MatchPredicate_ReturnListOfRecord()
        {
            var receiptNote1 = new ReceiptNote
            {
                BranchID = 1,
                ReceiptNumber = "1"
            };
            var receiptNote2 = new ReceiptNote
            {
                BranchID = 2,
                ReceiptNumber = "2"
            };

            da.Save(receiptNote1);
            da.Save(receiptNote2);

            var result = da.List(x => x.BranchID == 1).ToList();

            Assert.AreEqual(1, result.Count);

            result = da.List(x => x.ReceiptNumber == "2").ToList();

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void List_DatabaseHasData_DoesNotMatchPredicate_ReturnEmpty()
        {
            var receiptNote1 = new ReceiptNote
            {
                BranchID = 1,
                ReceiptNumber = "1"
            };
            var receiptNote2 = new ReceiptNote
            {
                BranchID = 2,
                ReceiptNumber = "2"
            };

            da.Save(receiptNote1);
            da.Save(receiptNote2);

            var result = da.List(x => x.BranchID == 3).ToList();

            Assert.AreEqual(0, result.Count);

            result = da.List(x => x.ReceiptNumber.Contains("3")).ToList();

            Assert.AreEqual(0, result.Count);
        }
    }
}
