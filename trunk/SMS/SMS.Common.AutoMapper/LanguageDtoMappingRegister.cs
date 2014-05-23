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
                    UserContext.Language == "vn" ? z.VNName : z.ENName));

            Mapper.CreateMap<Table, LanguageTableDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName));

            Mapper.CreateMap<Product, LanguageProductDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName));

            Mapper.CreateMap<InvoiceTable, LanguageInvoiceTableDto>();

            Mapper.CreateMap<InvoiceDetail, LanguageInvoiceDetailDto>()
                .ForMember(x => x.ProductName, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.ProductVNName : z.ProductENName))
                .ForMember(x => x.UnitName, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.UnitVNName : z.UnitENName));

            Mapper.CreateMap<PageLabel, LanguagePageLabelDto>()
                .ForMember(x => x.Text, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNText : z.ENText));
        }
    }
}