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
            Map(x => x.MessageID).ReadOnly();
            Map(x => x.BranchID).ReadOnly();
            Map(x => x.VNMessage).ReadOnly();
            Map(x => x.ENMessage).ReadOnly();
        }
    }
}