using AutoMapper;
using Core.Common.Session;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Common.AutoMapper
{
    public class LanguageDtoMappingRegister
    {
        public static void Register()
        {
            Mapper.CreateMap<Area, LanguageAreaDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Unit, LanguageUnitDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<OrderStatus, LanguageOrderStatusDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Table, LanguageTableDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Product, LanguageProductDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<ProductCategory, LanguageProductCategoryDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNName : z.ENName))
                    .ForMember(x => x.Description, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNDescription: z.ENDescription));

            Mapper.CreateMap<InvoiceTable, LanguageInvoiceTableDto>();

            Mapper.CreateMap<OrderTable, LanguageOrderTableDto>();
            Mapper.CreateMap<OrderTable, OrderTableBasicDto>();
            Mapper.CreateMap<Order, OrderBasicDto>();

            Mapper.CreateMap<OrderDetail, LanguageOrderDetailDto>();

            Mapper.CreateMap<InvoiceDetail, LanguageInvoiceDetailDto>()
                .ForMember(x => x.ProductName, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.ProductVNName : z.ProductENName))
                .ForMember(x => x.UnitName, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.UnitVNName : z.UnitENName));

            Mapper.CreateMap<PageLabel, LanguagePageLabelDto>()
                .ForMember(x => x.Text, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNText : z.ENText));

            Mapper.CreateMap<ErrorMessage, LanguageErrorMessageDto>()
                .ForMember(x => x.Message, y => y.ResolveUsing(z =>
                    UserContext.Language == Language.Vietnamese ? z.VNMessage : z.ENMessage));

        }
    }
}