using System.Collections.Generic;
using System.Linq;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Common.Storage.Message
{
    public class SystemMessages
    {
        internal static IDictionary<long, IList<Message>> Messages { get; set; }

        public static string Get(long id)
        {
            var fallbackMessage = FallbackMessages.Get(id);
            var targetBranchID = id < 0 ? ConstConfig.NoBranchID : SmsSystem.SelectedBranchID;

            if (Messages.ContainsKey(targetBranchID) && Messages[targetBranchID].Any(x => x.MessageID == id))
                return Messages[targetBranchID].First(x => x.MessageID == id).Content;

            return string.Format("[{0}]", fallbackMessage);
        }
    }
}