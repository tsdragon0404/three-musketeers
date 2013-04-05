using TM.Framework;
using TM.Infrastructure.Entities;

namespace TM.Interfaces.BusinessServices
{
    public interface ICategoryBusinessServices
    {
        ServiceResult<Category> AddCategory(Category category);
    }
}
