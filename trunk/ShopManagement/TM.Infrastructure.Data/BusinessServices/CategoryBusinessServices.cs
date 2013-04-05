using TM.Framework;
using TM.Infrastructure.Data.Repositories;
using TM.Infrastructure.Entities;
using TM.Interfaces.BusinessServices;
using TM.Interfaces.Repositories;

namespace TM.Infrastructure.Data.BusinessServices
{
    public class CategoryBusinessServices : ICategoryBusinessServices
    {
        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository 
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository()); }
        }

        public ServiceResult<Category> AddCategory(Category category)
        {
            CategoryRepository.Add(category);
            CategoryRepository.SaveAllChanges();
            return new ServiceResult<Category> {Data = category};
        }
    }
}
