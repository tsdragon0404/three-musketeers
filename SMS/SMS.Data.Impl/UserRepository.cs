using Core.Data.NHibernate;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
    }
}
