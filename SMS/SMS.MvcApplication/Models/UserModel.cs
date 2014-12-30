using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class UserModel
    {
        public IList<UserInfoDto> Users { get; set; }
        public IList<UserConfigDto> UserConfigs { get; set; }
    }
}