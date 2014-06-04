using Core.Common.Validation;

namespace SMS.MvcApplication.Models
{
    public class JsonModel
    {
        private bool success = true;
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public object Data { get; set; }

        public static JsonModel Create<TDto>(ServiceResult<TDto> serviceResult)
        {
            return new JsonModel {Success = serviceResult.Success, Data = serviceResult.Data};
        }
        public static JsonModel Create(ServiceResult serviceResult)
        {
            return new JsonModel { Success = serviceResult.Success };
        }
        public static JsonModel Create(bool success)
        {
            return new JsonModel { Success = success };
        }
    }
}