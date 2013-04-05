using System;
using AutoMapper;
using TM.DataContracts;
using TM.Framework.Mapping;
using TM.Infrastructure.Entities;

namespace TM.Infrastructure.Data
{
    class MappingRegister : IMappingRegister
    {
        private static void MapTwoWay<TLeft, TRight>()
        {
            Mapper.CreateMap<TLeft, TRight>();
            Mapper.CreateMap<TRight, TLeft>();
        }

        public void Register()
        {
            MapTwoWay<Category, CategoryDTO>();
        }
    }
}
