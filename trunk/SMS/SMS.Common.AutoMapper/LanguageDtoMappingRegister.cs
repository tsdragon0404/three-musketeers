﻿using AutoMapper;
using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Common.AutoMapper
{
    public class LanguageDtoMappingRegister
    {
        public static void Register()
        {
            Mapper.CreateMap<Branch, LanguageBranchBasicDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Area, LanguageAreaDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Unit, LanguageUnitDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<OrderStatus, LanguageOrderStatusDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Table, LanguageTableDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<Product, LanguageProductDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName));

            Mapper.CreateMap<ProductCategory, LanguageProductCategoryDto>()
                .ForMember(x => x.Name, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNName : z.ENName))
                    .ForMember(x => x.Description, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNDescription : z.ENDescription));

            Mapper.CreateMap<InvoiceTable, LanguageInvoiceTableDto>();

            Mapper.CreateMap<OrderTable, LanguageOrderTableDto>();
            Mapper.CreateMap<OrderTable, OrderTableBasicDto>();
            Mapper.CreateMap<Order, OrderBasicDto>();

            Mapper.CreateMap<OrderDetail, LanguageOrderDetailDto>();

            Mapper.CreateMap<InvoiceDetail, LanguageInvoiceDetailDto>()
                .ForMember(x => x.ProductName, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.ProductVNName : z.ProductENName))
                .ForMember(x => x.UnitName, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.UnitVNName : z.UnitENName));

            Mapper.CreateMap<PageLabel, LanguagePageLabelDto>()
                .ForMember(x => x.Text, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNText : z.ENText));

            Mapper.CreateMap<Report, LanguageReportDto>()
                .ForMember(x => x.Title, y => y.ResolveUsing(z =>
                    SmsSystem.Language == Language.Vietnamese ? z.VNTitle : z.ENTitle));

            Mapper.CreateMap<LanguageOrderTableDto, PaymentTableDto>();
            Mapper.CreateMap<LanguageOrderDetailDto, PaymentDetailDto>();
        }
    }
}