namespace Core.Common.Validation
{
    public class ValidationError
    {
        public string Property { get; set; }
        public string OriginalMessage { get; set; }
        public object[] FormatArgs { get; set; }

        public string ErrorMessage
        {
            get { return string.Format(OriginalMessage, FormatArgs); }
        }

        public ValidationError(string property, string originalMessage, params object[] args)
        {
            Property = property;
            OriginalMessage = originalMessage;
            FormatArgs = args;
        }
    }
}