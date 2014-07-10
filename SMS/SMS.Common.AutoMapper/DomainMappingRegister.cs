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
            Map<Branch, BranchDto>();
            Map<BranchInfo, BranchInfoDto>();
            Map<Product, ProductDto>();
            Map<ProductCategory, ProductCategoryDto>();
            Map<Table, TableDto>();
            Map<Unit, UnitDto>();
            Map<Invoice, InvoiceDto>();
            Map<InvoiceTable, InvoiceTableDto>();
            Map<InvoiceDetail, InvoiceDetailDto>();
            Map<Area, AreaDto>();
            Map<Page, PageDto>();
            Map<PageMenu, PageMenuDto>();
            Map<PageLabel, PageLabelDto>();
            Map<Order, OrderDto>();
            Map<Order, PaymentDto>();
            Map<OrderTable, OrderTableDto>();
            Map<OrderTable, PaymentTableDto>();
            Map<OrderDetail, OrderDetailDto>();
            Map<OrderDetail, PaymentDetailDto>();
            Map<OrderStatus, OrderStatusDto>();
            Map<OrderDiscount, OrderDiscountDto>();
            Map<Customer, CustomerDto>();
            Map<ErrorMessage, ErrorMessageDto>();
            Map<User, UserDto>();
            Map<Role, RoleDto>();
            Map<Currency, CurrencyDto>();
            Map<OrderDto, PaymentDto>();
            Map<OrderDto, OrderDataDto>();
            Map<Reject, RejectDto>();

            Map<Report, ReportDto>();
            Map<ReportDatasource, ReportDatasourceDto>();
            Map<ReportDatasourceParameter, ReportDatasourceParameterDto>();
        }
    }
}
