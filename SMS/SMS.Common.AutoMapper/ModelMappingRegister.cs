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
            Mapper.CreateMap<Product, ProductBasicDto>();
            Mapper.CreateMap<Area, CashierAreaModel>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName)); ;
        }
    }
}