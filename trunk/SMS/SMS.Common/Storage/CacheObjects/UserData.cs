using System;
using System.Collections.Generic;
using System.Web;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Common.Storage.CacheObjects
{
    public class UserData : ICacheData
    {
        public Guid TokenID { get; set; }

        public long UserID { get; set; }
        public string UserName { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool UseSystemConfig { get; set; }

        public long CurrentBranchId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime LoginDateTime { get; set; }
        public DateTime LastAccess { get; set; }

        public IList<BranchName> AllowBranches { get; set; }
        public List<long> AllowPageIDs { get; set; }

        public int PageSize { get; set; }
        public long DefaultAreaID { get; set; }
        public string Theme { get; set; }

        /// <summary>
        /// Contain height value for List table section in Cashier page (in percent)
        /// </summary>
        public decimal ListTableHeight { get; set; }

        #region Implementation of ICacheData

        public object Key { get { return TokenID; } }
        public bool IsCurrent { get { return Guid.Parse(HttpContext.Current.Request.Headers.Get(ConstKey.Token)) == TokenID; } }

        #endregion
    }

    public class UserDataCollection : CacheDataCollection<UserData, Guid>
    {
    }

    public class BranchName
    {
        public long ID { get; set; }
        private string VNName { get; set; }
        private string ENName { get; set; }
        public string Name
        {
            get { return SmsSystem.Language == Language.Vietnamese ? VNName : ENName; }
        }

        public BranchName(long id, string vnName, string enName)
        {
            ID = id;
            VNName = vnName;
            ENName = enName;
        }
    }
}
