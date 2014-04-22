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
            Map<Product, ProductDto>();
            Map<ProductCategory, ProductCategoryDto>();
            Map<Table, TableDto>();
            Map<Unit, UnitDto>();
            Map<Invoice, InvoiceDto>();
            Map<InvoiceTable, InvoiceTableDto>();
            Map<InvoiceDetail, InvoiceDetailDto>();
            Map<Area, AreaDto>();

            #region Map 1 way

            Mapper.CreateMap<Product, ProductBasicDto>();

            #endregion
        }
    }
}
