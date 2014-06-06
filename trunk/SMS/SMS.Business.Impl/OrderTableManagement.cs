using System.Collections.Generic;
using System.Linq;
using Core.Common.Session;
using Core.Common.Validation;
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

        #endregion

        public ServiceResult<IList<TDto>> GetTablesByAreaID<TDto>(long areaID)
        {
            var usedTables = Repository.Find(x => (x.Table.Area.ID == areaID || areaID == 0 ) && x.Order.BranchID == UserContext.BranchID  && x.Table.Enable).ToList();

            var availableTables = TableRepository.Find(x => (x.Area.ID == areaID || areaID == 0) && x.Area.BranchID == UserContext.BranchID && !x.OrderTables.Any());

            usedTables.AddRange(availableTables.Select(table => new OrderTable
                                                                    {
                                                                        ID = 0,
                                                                        Table = table,
                                                                    }));

            return new ServiceResult<IList<TDto>>
                       {Data = Mapper.Map<IList<TDto>>(usedTables.OrderBy(x => x.Table.Area.SEQ).ThenBy(x => x.Table.ID).ToList())};
        }

        public ServiceResult<long> CreateOrderTable(long tableID)
        {
            var orderId = OrderManagement.CreateOrder();

            var orderTable = new OrderTable {Order = new Order {ID = orderId}, Table = new Table {ID = tableID}};
            Repository.Add(orderTable);

            return new ServiceResult<long> {Data = orderTable.ID};
        }

        public ServiceResult CheckTableStatus(long tableID)
        {
            var result = Repository.Find(x => x.Table.ID == tableID);
            return new ServiceResult {Success = result.Any()};
        }

        public ServiceResult<long> CreateMultiOrderTable(long[] tableID)
        {
            var orderId = OrderManagement.CreateOrder();
            foreach (var tblID in tableID)
            {
                var orderTable = new OrderTable {Order = new Order {ID = orderId}, Table = new Table {ID = tblID}};
                Repository.Add(orderTable);
            }
            return new ServiceResult<long> { Data = orderId };
        }

        public ServiceResult<TDto> MoveTable<TDto>(long orderTableID, long tableID)
        {
            var orderTable = Repository.Get(orderTableID);
            orderTable.Table = new Table {ID = tableID};
            Repository.Update(orderTable);

            var result = OrderRepository.Get(orderTableID);
            return new ServiceResult<TDto> { Data = result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result) }; 
        }
    }
}