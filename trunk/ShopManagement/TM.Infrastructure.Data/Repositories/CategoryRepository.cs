using TM.Infrastructure.Entities;
using TM.Interfaces.Repositories;

namespace TM.Infrastructure.Data.Repositories
{
    class CategoryRepository : NHibernateRepository<Category>, ICategoryRepository
    {
    }
}
