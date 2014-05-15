using AutoMapper;
using Core.Common.Session;
using SMS.Data.Dtos;
using SMS.Data.Dtos.Models;
using SMS.Data.Entities;

namespace SMS.Common.AutoMapper
{
    public class ModelMappingRegister
    {
        public static void Register()
        {
            Mapper.CreateMap<Product, ProductOrderDto>();
            Mapper.CreateMap<Area, AreaBasicDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName)); ;
        }
    }
}