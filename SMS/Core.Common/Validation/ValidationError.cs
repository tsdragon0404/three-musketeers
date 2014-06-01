namespace Core.Common.Validation
{
    public class ValidationError
    {
        public string Property { get; set; }
        public string OriginalMessage { get; set; }

        public string ErrorMessage(params object[] args)
        {
            return string.Format(OriginalMessage, args);
        }
    }
}