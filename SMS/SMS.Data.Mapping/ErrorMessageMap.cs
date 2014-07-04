using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ErrorMessageMap : ClassMap<ErrorMessage>
    {
        public ErrorMessageMap()
        {
            Table("ErrorMessage");
            Id(x => x.ID).Column("ErrorMessageID");
            Map(x => x.MessageID);
            Map(x => x.BranchID);
            Map(x => x.VNMessage);
            Map(x => x.ENMessage);
        }
    }
}