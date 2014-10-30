namespace SMS.Common.Session
{
    public class Branch
    {
        public long ID { get; set; }
        private string VNName { get; set; }
        private string ENName { get; set; }
        public string Name
        {
            get { return SmsSystem.Language == Language.Vietnamese ? VNName : ENName; }
        }

        public Branch(long id, string vnName, string enName)
        {
            ID = id;
            VNName = vnName;
            ENName = enName;
        }
    }
}
