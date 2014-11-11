using AutoMapper;
using Core.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    class MappingRegister : IMappingRegister
    {
        private void Map<TLeft, TRight>()
        {
            Mapper.CreateMap<TLeft, TRight>();
            Mapper.CreateMap<TRight, TLeft>();
        }

        public void Register()
        {
            Map<Product, ProductDto>();
        }
    }
}
