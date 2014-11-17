using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Common.Storage;

namespace SMS.Common.UnitTesting
{
    [TestClass]
    public class SmsCacheTest
    {
        private const CacheKey key = CacheKey.UserAccess;

        [TestMethod]
        public void TestAdd_Get_SimpleType_Success()
        {
            SmsCache.Add(key, () => "result");

            Assert.AreEqual("result", SmsCache.Get<string>(key));
        }

        [TestMethod]
        public void TestAdd_Get_Class_Success()
        {
            SmsCache.Add(key, () => new List<Storage.Message.Message> { new Storage.Message.Message(1, "vn", "en") });

            var result = SmsCache.Get<List<Storage.Message.Message>>(key);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].MessageID);
        }
    }
}
