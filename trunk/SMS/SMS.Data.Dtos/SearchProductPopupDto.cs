namespace SMS.Data.Dtos
{
    public class SearchProductPopupDto
    {
        public virtual long Id { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual long Price { get; set; }
    }
}
