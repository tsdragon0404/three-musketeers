using TM.Infrastructure.Entities;

namespace TM.Infrastructure.Data.Mappings
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Map(x => x.CategoryName);
        }
    }
}
