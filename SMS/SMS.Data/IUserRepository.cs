using SMS.Data.Entities;

namespace SMS.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void UpdateProfile(long userID, string password, string firstName, string lastName, string cellPhone, string email, string address);
        void SaveUserSystem(User user);
        void SaveUserBranch(User user);
    }
}