namespace SMS.Common.Constant
{
    public class ConstConfig
    {
        public static int NoBranchID = 0;

        /// <summary>
        /// Payment lock duration in second(s)
        /// </summary>
        public static int PaymentLockDuration = 180;

        /// <summary>
        /// Session timeout duration in minute(s)
        /// </summary>
        public static int SessionTimeoutDuration = 30;

        public static int DefaultPagesize = 5;
        public static int DefaultHeightForListTable = 65;

        /// <summary>
        /// Separator in Http response text
        /// Note: If you want to change this value, remember to change in app.ajax-loader.js accordingly
        /// </summary>
        public static string HttpResponseSeparator = "{{|}}";
    }
}
