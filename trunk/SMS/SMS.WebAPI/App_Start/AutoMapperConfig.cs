using SMS.Common.AutoMapper;

namespace SMS.WebAPI
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            DomainMappingRegister.Register();
            LanguageDtoMappingRegister.Register();
        }
    }
}