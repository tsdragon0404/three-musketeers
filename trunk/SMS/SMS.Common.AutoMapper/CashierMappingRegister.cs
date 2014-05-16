using AutoMapper;
using Core.Common.Session;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Common.AutoMapper
{
    public class CashierMappingRegister
    {
        public static void Register()
        {
            Mapper.CreateMap<Area, CashierAreaDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName));

            Mapper.CreateMap<Table, CashierTableDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName));

            Mapper.CreateMap<Product, CashierProductDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.VNName : z.ENName));

            Mapper.CreateMap<InvoiceTable, CashierInvoiceTableDto>();

            Mapper.CreateMap<InvoiceDetail, CashierInvoiceDetailDto>()
                .ForMember(x => x.ProductName, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.ProductVNName : z.ProductENName))
                .ForMember(x => x.UnitName, y => y.ResolveUsing(z =>
                    UserContext.Language == "vn" ? z.UnitVNName : z.UnitENName));

        }
    }
}