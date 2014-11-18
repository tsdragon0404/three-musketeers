using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Common.Storage;
using SMS.Common.Storage.CacheObjects;

namespace SMS.Common.UnitTesting
{
    [TestClass]
    public class SmsCacheTest
    {
        private const CacheKey key = CacheKey.UserAccess;

        [TestMethod]
        public void TestAdd_Get_SimpleType_Success()
        {
            ServerCache.Add(key, () => "result");

            Assert.AreEqual("result", ServerCache.Get<string>(key));
        }

        [TestMethod]
        public void TestAdd_Get_Class_Success()
        {
            var tokenID = Guid.NewGuid();
            ServerCache.Add(key, () => new UserDataCollection { new UserData { TokenID = tokenID } });

            var result = ServerCache.Get<UserDataCollection>(key);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(tokenID, result[0].TokenID);
        }
    }
}
