namespace SMS.Data.Dtos
{
    public class EnableSortableDto
    {
        public virtual bool Enable { get; set; }
        public virtual int SEQ { get; set; }

        public EnableSortableDto()
        {
            Enable = true;
            SEQ = 10;
        }
    }
}