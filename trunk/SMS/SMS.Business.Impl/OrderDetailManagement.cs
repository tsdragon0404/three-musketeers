﻿using AutoMapper;
using SMS.Common.Constant;
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
        public virtual IOrderStatusRepository OrderStatusRepository { get; set; }

        #endregion

        public TDto AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            var product = ProductRepository.Get(productID);
            if (product == null)
                return Mapper.Map<TDto>(new OrderTable());
            var orderDetail = new OrderDetail
                                  {
                                      OrderTable = new OrderTable {ID = orderTableID},
                                      Quantity = quantity,
                                      Product = product,
                                      OrderStatus = OrderStatusRepository.Get(5) // default đã hoàn thành
                                  };
            Repository.Add(orderDetail);
            return Mapper.Map<TDto>(OrderTableRepository.Get(orderTableID));
        }

        public bool UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            var orderDetail = Repository.Get(orderDetailID);
            if (orderDetail == null)
                return false;
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
            }
            Repository.Update(orderDetail);

            return true;
        }

        public TDto UpdateOrderedProductStatus<TDto>(long orderDetailID, int value)
        {
            var orderDetail = Repository.Get(orderDetailID);
            if (orderDetail == null)
                return Mapper.Map<TDto>(new OrderDetail());
            orderDetail.OrderStatus = OrderStatusRepository.Get(value);
            Repository.Update(orderDetail);

            return Mapper.Map<TDto>(orderDetail);
        }
    }
}