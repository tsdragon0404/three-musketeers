using TM.Infrastructure.Data.Repositories;
using TM.Infrastructure.Entities;
using TM.Interfaces.BusinessServices;
using TM.Interfaces.Repositories;

namespace TM.Infrastructure.Data.BusinessServices
{
    public class CategoryBusinessServices : ICategoryBusinessServices
    {
        public CategoryBusinessServices()
        {
            CategoryRepository = new CategoryRepository();
        }

        public ICategoryRepository CategoryRepository { get; set; }


        public void AddCategory(Category category)
        {
            CategoryRepository.Add(category);
            CategoryRepository.SaveAllChanges();
        }
    }
}
