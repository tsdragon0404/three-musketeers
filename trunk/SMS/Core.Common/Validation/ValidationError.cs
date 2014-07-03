namespace Core.Common.Validation
{
    public class ValidationError
    {
        public string OriginalMessage { get; set; }
        public object[] FormatArgs { get; set; }

        public string ErrorMessage
        {
            get { return string.Format(OriginalMessage, FormatArgs); }
        }

        public ValidationError(string originalMessage, params object[] args)
        {
            OriginalMessage = originalMessage;
            FormatArgs = args;
        }
    }
}