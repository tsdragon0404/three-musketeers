using TM.CoreServices.Contracts;
using TM.DataContracts;
using TM.Framework;
using TM.Infrastructure.Data.ApplicationServices;
using TM.Interfaces.ApplicationServices;

namespace TM.CoreServices
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryApplicationServices _categoryApplicationServices;
        public ICategoryApplicationServices CategoryApplicationServices
        {
            get { return _categoryApplicationServices ?? (_categoryApplicationServices = new CategoryApplicationServices()); }
        }

        public ServiceResult<CategoryDTO> AddCategory(CategoryDTO categoryDTO)
        {
            return CategoryApplicationServices.AddCategory(categoryDTO);
        }
    }
}
