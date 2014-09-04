using SMS.Data.Dtos;

namespace SMS.MvcApplication.Models
{
    public class UserProfileModel
    {
        public UserBasicDto UserBasic { get; set; }
        public UserConfigDto UserConfig { get; set; }
    }
}