using TM.DataContracts;
using TM.Framework;

namespace TM.CoreServices.Contracts
{
    public interface ICategoryServices
    {
        ServiceResult<CategoryDTO> AddCategory(CategoryDTO categoryDTO);
    }
}
