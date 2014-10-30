using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Common.Storage.BranchConfig;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderDetailManagement : BaseManagement<OrderDetailDto, OrderDetail, IOrderDetailRepository>, IOrderDetailManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }
        public virtual IOrderTableRepository OrderTableRepository { get; set; }
        public virtual IOrderTableManagement OrderTableManagement { get; set; }
        public virtual IRejectRepository RejectRepository { get; set; }

        #endregion

        public ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            var product = ProductRepository.GetByID(productID);
            if (product == null)
                return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(new OrderTable()));
            var orderDetail = new OrderDetail
                                  {
                                      OrderTable = new OrderTable {ID = orderTableID},
                                      Quantity = quantity,
                                      Product = product,
                                      OrderStatus = BranchConfigs.Current.UseKitchenFunction ? OrderStatus.Ordered : OrderStatus.Done
                                  };
            Repository.Save(orderDetail);
            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(OrderTableRepository.GetByID(orderTableID)));
        }

        public ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            var orderDetail = Repository.GetByID(orderDetailID);
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
            Repository.Save(orderDetail);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, int value)
        {
            var orderDetail = Repository.GetByID(orderDetailID);
            if (orderDetail == null)
                return ServiceResult<TDto>.CreateFailResult();
            orderDetail.OrderStatus = (OrderStatus)value;
            Repository.Save(orderDetail);

            if(orderDetail.OrderStatus == OrderStatus.KitchenRejected)
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
            var orderProducts = Repository.List(x => x.OrderStatus == OrderStatus.SentToKitchen && x.OrderTable.Order.Branch.ID == SmsSystem.SelectedBranchID).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(orderProducts));
        }

        public ServiceResult<IList<TDto>> GetAcceptedProductForKitchen<TDto>()
        {
            var orderProducts = Repository.List(x => x.OrderStatus == OrderStatus.KitchenAccepted && x.OrderTable.Order.Branch.ID == SmsSystem.SelectedBranchID).ToList();
            return new ServiceResult<IList<TDto>> { Data = Mapper.Map<IList<TDto>>(orderProducts) };
        }
    }
}