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
            Map<Area, AreaDto>();
            Map<Branch, BranchDto>();
            Map<Branch, Session.Branch>();
            Map<BranchInfo, BranchInfoDto>();
            Map<BranchTax, BranchTaxDto>();
            Map<Currency, CurrencyDto>();
            Map<Customer, CustomerDto>();
            Map<ErrorMessage, ErrorMessageDto>();
            Map<ErrorMessage, Message.Message>();
            Map<InvoiceDetail, InvoiceDetailDto>();
            Map<Invoice, InvoiceDto>();
            Map<InvoiceDiscount, InvoiceDiscountDto>();
            Map<InvoiceTable, InvoiceTableDto>();
            Map<OrderDetail, OrderDetailDto>();
            Map<OrderDiscount, OrderDiscountDto>();
            Map<Order, OrderDto>();
            Map<OrderStatus, OrderStatusDto>();
            Map<OrderTable, OrderTableDto>();
            Map<Page, PageDto>();
            Map<PageLabel, PageLabelDto>();
            Map<PageMenu, PageMenuDto>();
            Map<ProductCategory, ProductCategoryDto>();
            Map<Product, ProductDto>();
            Map<Reject, RejectDto>();
            Map<ReportDatasource, ReportDatasourceDto>();
            Map<ReportDatasourceParameter, ReportDatasourceParameterDto>();
            Map<Report, ReportDto>();
            Map<Role, RoleDto>();
            Map<Table, TableDto>();
            Map<Tax, TaxDto>();
            Map<Unit, UnitDto>();
            Map<UserBranch, UserBranchDto>();
            Map<User, UserDto>();
            Map<User, UserBasicDto>();
            Map<OrderDto, OrderDataDto>();
        }
    }
}
