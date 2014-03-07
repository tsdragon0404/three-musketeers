using System.Collections.Generic;
using FMS.Dtos;

namespace FMS.AppService
{
    public interface ISectionAppService
    {
        IList<SectionDto> GetAllSection();
    }
}
