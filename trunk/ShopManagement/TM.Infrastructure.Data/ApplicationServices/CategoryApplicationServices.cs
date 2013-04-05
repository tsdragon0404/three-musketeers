using TM.DataContracts;
using TM.Framework;
using TM.Framework.Mapping;
using TM.Infrastructure.Data.BusinessServices;
using TM.Infrastructure.Entities;
using TM.Interfaces.ApplicationServices;
using TM.Interfaces.BusinessServices;

namespace TM.Infrastructure.Data.ApplicationServices
{
    public class CategoryApplicationServices : ICategoryApplicationServices
    {
        public CategoryApplicationServices()
        {
            var mappingRegister = new MappingRegister();
            mappingRegister.Register();
        }

        private IMappingEngine _mappingEngine;

        public IMappingEngine MappingEngine
        {
            get { return _mappingEngine ?? (_mappingEngine = new AutoMapperEngine()); }
        }

        private ICategoryBusinessServices _categoryBusinessServices;
        public ICategoryBusinessServices CategoryBusinessServices
        {
            get { return _categoryBusinessServices ?? (_categoryBusinessServices = new CategoryBusinessServices()); }
        }

        public ServiceResult<CategoryDTO> AddCategory(CategoryDTO categoryDTO)
        {
            var domainCategory = MappingEngine.Map<CategoryDTO, Category>(categoryDTO);
            var result = CategoryBusinessServices.AddCategory(domainCategory);
            return new ServiceResult<CategoryDTO>{ Data = MappingEngine.Map<Category, CategoryDTO>(result.Data)};
        }
    }
}
