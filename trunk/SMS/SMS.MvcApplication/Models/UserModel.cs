using System.Collections.Generic;
using SMS.Common.Paging;
using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class UserModel
    {
        public IPagedList<UserInfoDto> Users { get; set; }
        public IList<UserConfigDto> UserConfigs { get; set; }
    }
}