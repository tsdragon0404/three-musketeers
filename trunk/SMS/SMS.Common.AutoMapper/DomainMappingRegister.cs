using AutoMapper;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Common.AutoMapper
{
    public class DomainMappingRegister
    {
        private static void Map<TLeft, TRight>()
        {
            Mapper.CreateMap<TLeft, TRight>();
            Mapper.CreateMap<TRight, TLeft>();
        }

        public static void Register()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductCategory, ProductCategoryDto>();
            Mapper.CreateMap<Table, TableDto>();
            Mapper.CreateMap<Unit, UnitDto>();
            Mapper.CreateMap<Invoice, InvoiceDto>();
            Mapper.CreateMap<InvoiceTable, InvoiceTableDto>();
            Mapper.CreateMap<InvoiceDetail, InvoiceDetailDto>();
            Mapper.CreateMap<Area, AreaDto>();

            Mapper.CreateMap<Product, ProductBasicDto>();
        }
    }
}
