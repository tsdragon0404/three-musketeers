namespace Core.Common.Validation
{
    public class Error
    {
        public string OriginalMessage { get; set; }
        public object[] FormatArgs { get; set; }
        public ErrorType Type { get; set; }

        public string ErrorMessage
        {
            get { return string.Format(OriginalMessage, FormatArgs); }
        }

        public Error(string originalMessage, ErrorType type, params object[] args)
        {
            OriginalMessage = originalMessage;
            Type = type;
            FormatArgs = args;
        }
    }
}