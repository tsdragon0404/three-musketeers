using System.Collections.Generic;
using FMS.Dtos;

namespace FMS.Business
{
    public interface ISectionManagement
    {
        IList<SectionDto> ListAllSection();
    }
}
