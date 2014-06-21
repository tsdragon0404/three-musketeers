﻿using AutoMapper;
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
            Map<Page, PageDto>();
            Map<PageLabel, PageLabelDto>();
            Map<Order, OrderDto>();
            Map<OrderTable, OrderTableDto>();
            Map<OrderDetail, OrderDetailDto>();
            Map<OrderStatus, OrderStatusDto>();
            Map<OrderDiscount, OrderDiscountDto>();
            Map<Customer, CustomerDto>();
            Map<ErrorMessage, ErrorMessageDto>();

            Map<Report, ReportDto>();
            Map<ReportDatasource, ReportDatasourceDto>();
            Map<ReportDatasourceParameter, ReportDatasourceParameterDto>();
        }
    }
}
