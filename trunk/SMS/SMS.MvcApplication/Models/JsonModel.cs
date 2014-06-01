namespace SMS.MvcApplication.Models
{
    public class JsonModel
    {
        private bool success = true;
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public object Data { get; set; }
    }
}