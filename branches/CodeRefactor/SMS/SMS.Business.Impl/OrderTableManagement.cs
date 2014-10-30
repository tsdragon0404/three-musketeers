using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderTableManagement : BaseManagement<OrderTableDto, OrderTable, IOrderTableRepository>, IOrderTableManagement
    {
        #region Fields

        public virtual ITableRepository TableRepository { get; set; }
        public virtual IOrderDetailRepository OrderDetailRepository { get; set; }
        public virtual IOrderRepository OrderRepository { get; set; }
        public virtual IOrderManagement OrderManagement { get; set; }

        #endregion

        public ServiceResult<IList<TDto>> GetTablesByAreaID<TDto>(long areaID)
        {
            var usedTables = Repository.List(x => (x.Table.Area.ID == areaID || areaID == 0) && x.Order.Branch.ID == SmsSystem.SelectedBranchID && x.Table.Enable).ToList();

            var availableTables = TableRepository.List(x => (x.Area.ID == areaID || areaID == 0) && x.Area.Branch.ID == SmsSystem.SelectedBranchID && !x.OrderTables.Any());

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
            Repository.Save(orderTable);

            return ServiceResult<long>.CreateSuccessResult(orderTable.ID);
        }

        public ServiceResult CheckTableStatus(long tableID)
        {
            var result = Repository.Exists(x => x.Table.ID == tableID);
            return ServiceResult.CreateResult(result);
        }

        public ServiceResult<long> CreateMultiOrderTable(long[] tableID)
        {
            var orderId = OrderManagement.CreateOrder();
            foreach (var tblID in tableID)
            {
                var orderTable = new OrderTable {Order = new Order {ID = orderId}, Table = new Table {ID = tblID}};
                Repository.Save(orderTable);
            }
            return ServiceResult<long>.CreateSuccessResult(orderId);
        }

        public ServiceResult<TDto> MoveTable<TDto>(long orderTableID, long tableID)
        {
            var orderTable = Repository.GetByID(orderTableID);
            orderTable.Table = new Table {ID = tableID};
            Repository.Save(orderTable);

            var result = OrderRepository.GetByID(orderTableID);
            return ServiceResult<TDto>.CreateSuccessResult(result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result)); 
        }

        //TODO: test SaveAllChanges
        public ServiceResult PoolingTable(long[] orderTable)
        {
            var orderTableFirst = new OrderTable {ID = 0};
            
            foreach (var id in orderTable)
            {
                if (orderTableFirst.ID == 0)
                    orderTableFirst = Repository.GetByID(id) ?? orderTableFirst;
                else
                {
                    var orderTableID = id;
                    var orderDetailList = OrderDetailRepository.List(x => x.OrderTable.ID == orderTableID).ToList();
                    if (orderDetailList.Any())
                    {
                        foreach (var orderDetail in orderDetailList)
                        {
                            orderDetail.OrderTable = orderTableFirst;
                            OrderDetailRepository.Save(orderDetail);
                            //OrderDetailRepository.SaveAllChanges();
                        }
                    }
                    var orderID = Repository.GetByID(orderTableID).Order.ID;
                    Repository.Delete(orderTableID);
                    //Repository.SaveAllChanges();
                    if (!Repository.Exists(x => x.Order.ID == orderID))
                        OrderRepository.Delete(orderID);
                }
            }
            return ServiceResult.CreateSuccessResult();
        }

        //TODO: test SaveAllChanges
        public ServiceResult SendToKitchen(long orderTableID)
        {
            var orderDetailList =
                OrderDetailRepository.List(
                    x =>
                    x.OrderTable.ID == orderTableID &&
                    (x.OrderStatus == OrderStatus.Ordered ||
                     x.OrderStatus == OrderStatus.KitchenRejected)).ToList();
            if (orderDetailList.Any())
            {
                foreach (var orderDetail in orderDetailList)
                {
                    orderDetail.OrderStatus = OrderStatus.SentToKitchen;
                    OrderDetailRepository.Save(orderDetail);
                    //OrderDetailRepository.SaveAllChanges();
                }
            }
            return ServiceResult.CreateSuccessResult();
        }
    }
}