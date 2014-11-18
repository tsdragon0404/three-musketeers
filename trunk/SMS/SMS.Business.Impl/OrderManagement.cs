using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Common.Storage;
using SMS.Common.Storage;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderManagement : BaseManagement<OrderDto, Order, IOrderRepository>, IOrderManagement
    {
        #region Fields

        public virtual ITableRepository TableRepository { get; set; }
        public virtual IProductRepository ProductRepository { get; set; }
        public virtual IInvoiceRepository InvoiceRepository { get; set; }
        public virtual IRejectRepository RejectRepository { get; set; }

        //public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }
        //public virtual IInvoiceDetailRepository InvoiceDetailRepository { get; set; }
        //public virtual IInvoiceDiscountRepository InvoiceDiscountRepository { get; set; }

        #endregion

        public ServiceResult<TDto> GetByOrderTableID<TDto>(long orderTableID)
        {
            var result = Repository.Get(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));
            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(result ?? new Order()));
        }

        public long CreateEmptyOrder()
        {
            var order = new Order();
            Repository.Save(order);
            return order.ID;
        }

        public ServiceResult DeleteByOrderTableID(long orderTableID)
        {
            var order = Repository.Get(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));

            return order == null 
                ? ServiceResult.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business)) 
                : ServiceResult.CreateResult(Repository.Delete(order.ID));
        }

        public override ServiceResult<TModel> GetByID<TModel>(long primaryKey)
        {
            var result = Repository.GetByID(primaryKey);
            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(result ?? new Order()));
        }

        public ServiceResult DeleteMultiOrder(long[] orderIds)
        {
            orderIds.Apply(x => Repository.Delete(x));
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription)
        {
            Repository.UpdateOtherFee(orderID, otherFee, otherFeeDescription);
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult Payment(long orderID, decimal tax, decimal serviceFee)
        {
            var order = Repository.GetByID(orderID);

            if (order == null)
                return ServiceResult.CreateFailResult();

            InvoiceRepository.CreateInvoice(order, SmsSystem.UserContext.UserID, SmsCache.BranchConfigs.Current.Currency, tax, serviceFee);

            Repository.Delete(orderID);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult <IList<TDto>> GetOrderDiscount<TDto>(long orderID)
        {
            var order = Repository.Get(x => x.ID == orderID);

            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(order.OrderDiscounts));
        }

        public ServiceResult SaveOrderDiscount(long orderID, OrderDiscountDto[] orderDiscounts)
        {
            var discounts = Mapper.Map<OrderDiscount[]>(orderDiscounts);
            Repository.SaveDiscounts(orderID, discounts);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult ChangeCustomer(long orderID, long customerID, string customerName, string address, string cellPhone, string dob)
        {
            var order = Repository.GetByID(orderID);
            if (order == null)
                return ServiceResult.CreateFailResult();

            if (customerID > 0)
            {
                order.Customer = new Customer { ID = customerID };
                order.CustomerName = String.Empty;
                order.Address = String.Empty;
                order.CellPhone = String.Empty;
                order.DOB = null;
            }
            else
            {
                order.Customer = null;
                order.CustomerName = customerName;
                order.Address = address;
                order.CellPhone = cellPhone;
                if (dob.Trim() != "") 
                    order.DOB = DateTime.Parse(dob);
                else
                    order.DOB = null;
            }
            Repository.Save(order);
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult<IList<TDto>> GetOrderTablesByAreaID<TDto>(long areaID)
        {
            var orders = Repository
                .List(x => x.OrderTables.Any(y => y.Table.Area.ID == areaID || areaID == 0) && x.Branch.ID == SmsSystem.SelectedBranchID);

            var usedTables = new List<OrderTable>();
            orders.Apply(x => usedTables.AddRange(x.OrderTables));

            var availableTables = TableRepository
                .List(x => (x.Area.ID == areaID || areaID == 0) && x.Area.Branch.ID == SmsSystem.SelectedBranchID && !x.OrderTables.Any() && x.Enable);

            usedTables.AddRange(availableTables.Select(table => new OrderTable
                                                                    {
                                                                        ID = 0,
                                                                        Table = table,
                                                                    }));

            return ServiceResult<IList<TDto>>.CreateSuccessResult(
                       Mapper.Map<IList<TDto>>(usedTables.OrderBy(x => x.Table.Area.SEQ).ThenBy(x => x.Table.ID).ToList()));
        }

        private string BuildOrderNumber(long orderID)
        {
            var text = "0000000000" + orderID;
            return "INV-" + text.Substring(text.Length - 10, 10);
        }

        public ServiceResult<long> CreateOrderTable(long orderID, long tableID)
        {
            var order = Repository.GetByID(orderID);
            order.Customer = new Customer {ID = 1};
            order.OrderTables.Add(new OrderTable {Table = new Table {ID = tableID}});
                
            order.OrderNumber = BuildOrderNumber(orderID);
            Repository.Save(order);

            return ServiceResult<long>.CreateSuccessResult(order.OrderTables[0].ID);
        }

        public ServiceResult CheckTableStatus(long tableID)
        {
            var result = Repository.Exists(x => x.OrderTables.Any(y => y.Table.ID == tableID));
            return ServiceResult.CreateResult(result);
        }

        public ServiceResult<long> CreateMultiOrderTable(long orderID, long[] tableID)
        {
            var order = Repository.GetByID(orderID);
            order.Customer = new Customer { ID = 1 };
            order.OrderTables = tableID.Select(x => new OrderTable { Table = new Table { ID = x } }).ToList();

            order.OrderNumber = BuildOrderNumber(orderID);
            Repository.Save(order);

            return ServiceResult<long>.CreateSuccessResult(order.ID);
        }

        public ServiceResult<TDto> MoveTable<TDto>(long orderTableID, long tableID)
        {
            var order = Repository.Get(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));
            if (order == null)
                return ServiceResult<TDto>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            order.OrderTables.First(x => x.ID == orderTableID).Table = new Table { ID = tableID };
            Repository.Save(order);

            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(order));
        }

        public ServiceResult PoolingTable(long[] orderTableIds)
        {
            var orders = Repository.List(x => x.OrderTables.Any(y => orderTableIds.Contains(y.ID))).ToList();
            var orderTableFirst = new OrderTable { ID = 0 };

            foreach (var id in orderTableIds)
            {
                var order = orders.First(x => x.OrderTables.Any(y => y.ID == id));
                if (orderTableFirst.ID == 0)
                    orderTableFirst = order.OrderTables.First(y => y.ID == id);
                else
                {
                    var orderTable = order.OrderTables.First(y => y.ID == id);

                    orderTable.OrderDetails.Apply(orderDetail =>
                                                 orderTableFirst.OrderDetails.Add(new OrderDetail
                                                                                      {
                                                                                          Comment = orderDetail.Comment,
                                                                                          Discount = orderDetail.Discount,
                                                                                          DiscountCode = orderDetail.DiscountCode,
                                                                                          DiscountComment = orderDetail.DiscountComment,
                                                                                          DiscountType = orderDetail.DiscountType,
                                                                                          KitchenComment = orderDetail.KitchenComment,
                                                                                          OrderStatus = orderDetail.OrderStatus,
                                                                                          Product = orderDetail.Product,
                                                                                          Quantity = orderDetail.Quantity
                                                                                      }));
                    order.OrderTables.Remove(orderTable);
                    if (!order.OrderTables.Any())
                        Repository.Delete(order.ID);
                }
            }
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult SendToKitchen(long orderTableID)
        {
            var order = Repository.Get(x => x.OrderTables.Any(y => y.ID == orderTableID));
            if (order == null)
                return ServiceResult.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            var orderTable = order.OrderTables.First(y => y.ID == orderTableID);

            foreach (var orderDetail in orderTable.OrderDetails.Where(x => x.OrderStatus == OrderStatus.Ordered || x.OrderStatus == OrderStatus.KitchenRejected))
                orderDetail.OrderStatus = OrderStatus.SentToKitchen;

            Repository.Save(order);
            
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            var product = ProductRepository.GetByID(productID);
            if (product == null)
                return ServiceResult<TDto>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            var order = Repository.Get(x => x.OrderTables.Any(y => y.ID == orderTableID));
            if (order == null)
                return ServiceResult<TDto>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            var orderTable = order.OrderTables.First(y => y.ID == orderTableID);
            orderTable.OrderDetails.Add(new OrderDetail
                                            {
                                                Quantity = quantity,
                                                Product = product,
                                                OrderStatus = SmsCache.BranchConfigs.Current.UseKitchenFunction ? OrderStatus.Ordered : OrderStatus.Done
                                            });
            Repository.Save(order);

            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(orderTable));
        }

        public ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            var order = Repository.Get(x => x.OrderTables.Any(y => y.OrderDetails.Any(z => z.ID == orderDetailID)));
            if (order == null)
                return ServiceResult.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            var orderTable = order.OrderTables.First(y => y.OrderDetails.Any(z => z.ID == orderDetailID));
            var orderDetail = orderTable.OrderDetails.First(z => z.ID == orderDetailID);

            switch (columnName)
            {
                case "qty":
                    orderDetail.Quantity = decimal.Parse(value);
                    break;
                case "cmt":
                    orderDetail.Comment = value;
                    break;
                case "discount":
                    {
                        orderDetail.Discount = decimal.Parse(value);
                        orderDetail.DiscountCode = "";
                        orderDetail.DiscountType = DiscountType.Number;
                        orderDetail.DiscountComment = "";
                        break;
                    }
                case "kitchenComment":
                    orderDetail.KitchenComment = value;
                    break;

            }
            Repository.Save(order);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, int value)
        {
            var order = Repository.Get(x => x.OrderTables.Any(y => y.OrderDetails.Any(z => z.ID == orderDetailID)));
            if (order == null)
                return ServiceResult<TDto>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            var orderTable = order.OrderTables.First(y => y.OrderDetails.Any(z => z.ID == orderDetailID));
            var orderDetail = orderTable.OrderDetails.First(z => z.ID == orderDetailID);

            orderDetail.OrderStatus = (OrderStatus)value;
            Repository.Save(order);

            if (orderDetail.OrderStatus == OrderStatus.KitchenRejected)
            {
                RejectRepository.Save(new Reject
                                         {
                                             BranchID = SmsSystem.SelectedBranchID,
                                             ProductCode = orderDetail.Product.ProductCode,
                                             ProductVNName = orderDetail.Product.VNName,
                                             ProductENName = orderDetail.Product.ENName,
                                             Quantity = orderDetail.Quantity,
                                             UnitVNName = orderDetail.Product.Unit.VNName,
                                             UnitENName = orderDetail.Product.Unit.ENName,
                                             OrderComment = orderDetail.Comment,
                                             KitchenComment = orderDetail.KitchenComment,
                                             CreatedDate = DateTime.Now,
                                             CreatedUser = SmsSystem.UserContext.UserName
                                         });
            }

            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(orderDetail));
        }

        public ServiceResult<IList<TDto>> GetOrderedProductForKitchen<TDto>()
        {
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(Repository.GetOrderDetailByStatus(OrderStatus.SentToKitchen, SmsSystem.SelectedBranchID)));
        }

        public ServiceResult<IList<TDto>> GetAcceptedProductForKitchen<TDto>()
        {
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(Repository.GetOrderDetailByStatus(OrderStatus.KitchenAccepted, SmsSystem.SelectedBranchID)));
        }
    }
}
