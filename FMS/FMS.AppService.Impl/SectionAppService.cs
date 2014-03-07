using System.Collections.Generic;
using FMS.Business;
using FMS.Dtos;

namespace FMS.AppService.Impl
{
    class SectionAppService : ISectionAppService
    {
        public ISectionManagement SectionManagement { get; set; }

        public IList<SectionDto> GetAllSection()
        {
            return SectionManagement.ListAllSection();
        }
    }
}
