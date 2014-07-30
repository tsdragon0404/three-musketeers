using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderTableManagement : BaseManagement<OrderTableDto, OrderTable, long, IOrderTableRepository>, IOrderTableManagement
    {
        #region Fields

        public virtual ITableRepository TableRepository { get; set; }
        public virtual IOrderDetailRepository OrderDetailRepository { get; set; }
        public virtual IOrderRepository OrderRepository { get; set; }
        public virtual IOrderManagement OrderManagement { get; set; }
        public virtual IOrderStatusRepository OrderStatusRepository { get; set; }

        #endregion

        public ServiceResult<IList<TDto>> GetTablesByAreaID<TDto>(long areaID)
        {
            var usedTables = Repository.Find(x => (x.Table.Area.ID == areaID || areaID == 0) && x.Order.Branch.ID == SmsSystem.SelectedBranchID && x.Table.Enable).ToList();

            var availableTables = TableRepository.Find(x => (x.Area.ID == areaID || areaID == 0) && x.Area.Branch.ID == SmsSystem.SelectedBranchID && !x.OrderTables.Any());

            usedTables.AddRange(availableTables.Select(table => new OrderTable
                                                                    {
                                                                        ID = 0,
                                                                        Table = table,
                                                                    }));

            return ServiceResult<IList<TDto>>.CreateSuccessResult(
                       Mapper.Map<IList<TDto>>(usedTables.OrderBy(x => x.Table.Area.SEQ).ThenBy(x => x.Table.ID).ToList()));
        }

        public ServiceResult<long> CreateOrderTable(long tableID)
        {
            var orderId = OrderManagement.CreateOrder();

            var orderTable = new OrderTable {Order = new Order {ID = orderId}, Table = new Table {ID = tableID}};
            Repository.Add(orderTable);

            return ServiceResult<long>.CreateSuccessResult(orderTable.ID);
        }

        public ServiceResult CheckTableStatus(long tableID)
        {
            var result = Repository.Find(x => x.Table.ID == tableID);
            return ServiceResult.CreateResult(result.Any());
        }

        public ServiceResult<long> CreateMultiOrderTable(long[] tableID)
        {
            var orderId = OrderManagement.CreateOrder();
            foreach (var tblID in tableID)
            {
                var orderTable = new OrderTable {Order = new Order {ID = orderId}, Table = new Table {ID = tblID}};
                Repository.Add(orderTable);
            }
            return ServiceResult<long>.CreateSuccessResult(orderId);
        }

        public ServiceResult<TDto> MoveTable<TDto>(long orderTableID, long tableID)
        {
            var orderTable = Repository.Get(orderTableID);
            orderTable.Table = new Table {ID = tableID};
            Repository.Update(orderTable);

            var result = OrderRepository.Get(orderTableID);
            return ServiceResult<TDto>.CreateSuccessResult(result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result)); 
        }

        public ServiceResult PoolingTable(long[] orderTable)
        {
            var orderTableFirst = new OrderTable {ID = 0};
            
            foreach (var id in orderTable)
            {
                if (orderTableFirst.ID == 0)
                    orderTableFirst = Repository.Get(id) ?? orderTableFirst;
                else
                {
                    var orderTableID = id;
                    var orderDetailList = OrderDetailRepository.Find(x => x.OrderTable.ID == orderTableID).ToList();
                    if (orderDetailList.Any())
                    {
                        foreach (var orderDetail in orderDetailList)
                        {
                            orderDetail.OrderTable = orderTableFirst;
                            OrderDetailRepository.Update(orderDetail);
                            OrderDetailRepository.SaveAllChanges();
                        }
                    }
                    var orderID = Repository.Get(orderTableID).Order.ID;
                    Repository.Delete(orderTableID);
                    Repository.SaveAllChanges();
                    if (!Repository.Exists(x => x.Order.ID == orderID))
                        OrderRepository.Delete(orderID);
                }
            }
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult SendToKitchen(long orderTableID)
        {
            var orderDetailList =
                OrderDetailRepository.Find(
                    x =>
                    x.OrderTable.ID == orderTableID &&
                    (x.OrderStatus.ID == ConstOrderStatus.Ordered ||
                     x.OrderStatus.ID == ConstOrderStatus.KitchenRejected)).ToList();
            if (orderDetailList.Any())
            {
                foreach (var orderDetail in orderDetailList)
                {
                    orderDetail.OrderStatus = OrderStatusRepository.Get(ConstOrderStatus.SentToKitchen);
                    OrderDetailRepository.Update(orderDetail);
                    OrderDetailRepository.SaveAllChanges();
                }
            }
            return ServiceResult.CreateSuccessResult();
        }
    }
}