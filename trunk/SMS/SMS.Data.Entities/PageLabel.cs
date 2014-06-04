namespace SMS.Data.Entities
{
    public class PageLabel : Entity
    {
        public virtual string LabelID { get; set; }

        public virtual Page Page { get; set; }

        public virtual string VNText { get; set; }

        public virtual string ENText { get; set; }
    }
}