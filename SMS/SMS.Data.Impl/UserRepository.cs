using System;
using System.Linq;
using Core.Common;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Func

        public override Func<User, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Branches.Any(b => b.ID == y);
            }
        }

        #endregion

        public void UpdateProfile(long userID, string password, string firstName, string lastName, string cellPhone, string email, string address)
        {
            var user = Get(userID);
            if (!string.IsNullOrEmpty(password))
                user.Password = EncryptionHelper.SHA256Hash(password);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.CellPhone = cellPhone;
            user.Email = email;
            user.Address = address;
            Update(user);
        }

        public void SaveUserSystem(User user)
        {
            var userSystem = Get(user.ID);
            if (userSystem != null)
            {
                if (!string.IsNullOrEmpty(user.Password))
                    userSystem.Password = EncryptionHelper.SHA256Hash(user.Password);
                userSystem.FirstName = user.FirstName;
                userSystem.LastName = user.LastName;
                userSystem.CellPhone = user.CellPhone;
                userSystem.Email = user.Email;
                userSystem.Address = user.Address;
                userSystem.IsLockedOut = user.IsLockedOut;
                userSystem.UseSystemConfig = user.UseSystemConfig;
                userSystem.Roles = user.Roles;
                userSystem.Branches = user.Branches;
                Update(userSystem);
            }
            else
            {
                Add(new User
                        {
                            Username = user.Username,
                            Password = EncryptionHelper.SHA256Hash(user.Password),
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            CellPhone = user.CellPhone,
                            Email = user.Email,
                            Address = user.Address,
                            IsLockedOut = user.IsLockedOut,
                            UseSystemConfig = user.UseSystemConfig,
                            Roles = user.Roles,
                            Branches = user.Branches
                        });
            }
        }

        public void SaveUserBranch(User user)
        {
            var userBranch = Get(user.ID);

            if (!string.IsNullOrEmpty(user.Password))
                userBranch.Password = EncryptionHelper.SHA256Hash(user.Password);
            userBranch.FirstName = user.FirstName;
            userBranch.LastName = user.LastName;
            userBranch.CellPhone = user.CellPhone;
            userBranch.Email = user.Email;
            userBranch.Address = user.Address;
            userBranch.Roles = user.Roles;
            Update(userBranch);
        }
    }
}
