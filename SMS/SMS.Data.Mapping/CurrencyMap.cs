using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class CurrencyMap : BaseMap<Currency>
    {
        public CurrencyMap()
        {
            Table("Currency");
            Map(x => x.Name);
            Map(x => x.Exchange);
        }
    }
}
