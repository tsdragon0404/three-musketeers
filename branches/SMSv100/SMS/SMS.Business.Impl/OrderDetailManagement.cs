using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Common.Storage.BranchConfig;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderDetailManagement : BaseManagement<OrderDetailDto, OrderDetail, long, IOrderDetailRepository>, IOrderDetailManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }
        public virtual IOrderTableRepository OrderTableRepository { get; set; }
        public virtual IOrderTableManagement OrderTableManagement { get; set; }
        public virtual IRejectRepository RejectRepository { get; set; }

        #endregion

        #region Func

        public override Func<OrderDetail, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.OrderTable != null
                                 && x.OrderTable.Order != null
                                 && x.OrderTable.Order.Branch != null
                                 && x.OrderTable.Order.Branch.ID == y;
            }
        }

        #endregion

        public ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            var product = ProductRepository.Get(productID);
            if (product == null)
                return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(new OrderTable()));
            var orderDetail = new OrderDetail
                                  {
                                      OrderTable = new OrderTable {ID = orderTableID},
                                      Quantity = quantity,
                                      Product = product,
                                      OrderStatus = BranchConfigs.Current.UseKitchenFunction ? OrderStatus.Ordered : OrderStatus.Done
                                  };
            Repository.Add(orderDetail);
            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(OrderTableRepository.Get(orderTableID)));
        }

        public ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            var orderDetail = Repository.Get(orderDetailID);
            if (orderDetail == null)
                return ServiceResult.CreateFailResult();
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
            Repository.Update(orderDetail);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, int value)
        {
            var orderDetail = Repository.Get(orderDetailID);
            if (orderDetail == null)
                return ServiceResult<TDto>.CreateFailResult();
            orderDetail.OrderStatus = (OrderStatus)value;
            Repository.Update(orderDetail);

            if(orderDetail.OrderStatus == OrderStatus.KitchenRejected)
            {
                RejectRepository.Add(new Reject
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
            var orderProducts = Repository.Find(x => x.OrderStatus == OrderStatus.SentToKitchen && x.OrderTable.Order.Branch.ID == SmsSystem.SelectedBranchID).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(orderProducts));
        }

        public ServiceResult<IList<TDto>> GetAcceptedProductForKitchen<TDto>()
        {
            var orderProducts = Repository.Find(x => x.OrderStatus == OrderStatus.KitchenAccepted && x.OrderTable.Order.Branch.ID == SmsSystem.SelectedBranchID).ToList();
            return new ServiceResult<IList<TDto>> { Data = Mapper.Map<IList<TDto>>(orderProducts) };
        }
    }
}