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
            da.ExecuteNonQuery("DELETE ReceiptNote");
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
        public void ListByIDs_DatabaseHasData_MatchID_ReturnListOfRecord()
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
            var receiptNote3 = new ReceiptNote
            {
                BranchID = 3,
                ReceiptNumber = "3"
            };

            da.Save(receiptNote1);
            da.Save(receiptNote2);
            da.Save(receiptNote3);

            var allRecords = da.ListAll().ToList();

            var result = da.ListByIDs(allRecords.Select(x => x.ReceiptNoteID)).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.BranchID == 1 && x.ReceiptNumber == "1"));
            Assert.AreEqual(1, result.Count(x => x.BranchID == 2 && x.ReceiptNumber == "2"));
            Assert.AreEqual(1, result.Count(x => x.BranchID == 3 && x.ReceiptNumber == "3"));
        }

        [TestMethod]
        public void ListByIDs_DatabaseHasData_NotMatchID_ReturnEmpty()
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
            var receiptNote3 = new ReceiptNote
            {
                BranchID = 3,
                ReceiptNumber = "3"
            };

            da.Save(receiptNote1);
            da.Save(receiptNote2);
            da.Save(receiptNote3);

            var result = da.ListByIDs(new long[] { 4, 5 }).ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetByID_DatabaseHasData_ReturnRecord()
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

            var firstRecord = da.ListAll().First();

            var result = da.GetByID(firstRecord.ReceiptNoteID);

            Assert.IsNotNull(result);
            Assert.AreEqual(firstRecord.BranchID, result.BranchID);
            Assert.AreEqual(firstRecord.ReceiptNumber, result.ReceiptNumber);
        }

        [TestMethod]
        public void GetByID_DatabaseDoesNotHaveData_ReturnNull()
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

            var result = da.GetByID(-1);

            Assert.IsNull(result);
        }
    }
}
