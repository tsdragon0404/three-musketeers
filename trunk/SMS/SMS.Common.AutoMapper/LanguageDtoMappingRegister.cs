using AutoMapper;
using SMS.Common.Enums;
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
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Branch, LanguageBranchDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Unit, LanguageUnitDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Table, LanguageTableDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Product, LanguageProductDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName))
                .ForMember(x => x.Description, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNDescription : z.ENDescription));

            Mapper.CreateMap<ProductCategory, LanguageProductCategoryDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName))
                    .ForMember(x => x.Description, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNDescription : z.ENDescription));

            Mapper.CreateMap<OrderTable, LanguageOrderTableDto>();
            Mapper.CreateMap<OrderTable, SimpleOrderTableDto>();
            Mapper.CreateMap<OrderTable, OrderTableForKitchenDto>();
            Mapper.CreateMap<Order, OrderBasicDto>();
            Mapper.CreateMap<Order, OrderDataDto>();

            Mapper.CreateMap<OrderDetail, LanguageOrderDetailDto>();
            Mapper.CreateMap<OrderDetail, OrderDetailForKitchen>();

            Mapper.CreateMap<Page, LanguagePageDto>()
                .ForMember(x => x.Title, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNTitle : z.ENTitle))
                .ForMember(x => x.Description, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNDescription : z.ENDescription));

            Mapper.CreateMap<PageLabel, LanguagePageLabelDto>()
                .ForMember(x => x.Text, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNText : z.ENText));

            Mapper.CreateMap<Product, SearchProductDto>()
                .ForMember(x => x.Code, y => y.MapFrom(z => z.ProductCode))
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName))
                .ForMember(x => x.CategoryName, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.ProductCategory.VNName : z.ProductCategory.ENName))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

            Mapper.CreateMap<Product, ProductForKitchenDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName))
                .ForMember(x => x.CategoryName, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.ProductCategory.VNName : z.ProductCategory.ENName))
                .ForMember(x => x.UnitName, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.Unit.VNName : z.Unit.ENName));

            Mapper.CreateMap<Data.Entities.Inventory.ProductCategory, LanguageProductCategoryDto>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.ProductCategoryID))
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNName : z.ENName))
                .ForMember(x => x.Description, y => y.ResolveUsing(z =>
                    CommonObjects.Language == Language.Vietnamese ? z.VNDescription : z.ENDescription));
        }
    }
}