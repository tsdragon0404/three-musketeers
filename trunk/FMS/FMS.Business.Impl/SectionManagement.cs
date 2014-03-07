using System.Collections.Generic;
using System.Linq;
using FMS.Data;
using FMS.Dtos;
using AutoMapper;
using FMS.Entities;

namespace FMS.Business.Impl
{
    public class SectionManagement : ISectionManagement
    {
        public ISectionRepository SectionRepository { get; set; }

        public SectionManagement()
        {
            //SectionRepository = new SectionRepository();
        }
        public IList<SectionDto> ListAllSection()
        {
            var resultList = SectionRepository.ListAll().ToList();
            return Mapper.Map<IList<Section>, IList<SectionDto>>(resultList);
        }
    }
}
