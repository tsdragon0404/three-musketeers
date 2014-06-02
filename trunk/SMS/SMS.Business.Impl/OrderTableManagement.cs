using System.Collections.Generic;
using System.Linq;
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

        public IList<TDto> GetTablesByAreaID<TDto>(long areaID)
        {
            var usedTables = Repository.Find(x => x.Table.Area.ID == areaID && x.Table.Enable).ToList();

            var availableTables = TableRepository.Find(x => x.Area.ID == areaID && !x.OrderTables.Any());

            usedTables.AddRange(availableTables.Select(table => new OrderTable
                                                                    {
                                                                        ID = 0,
                                                                        Table = table,
                                                                    }));

            return Mapper.Map<IList<TDto>>(usedTables.OrderBy(x => x.Table.SEQ).ToList());
        }

        public long CreateOrderTable(long tableID)
        {
            var orderId = OrderManagement.CreateOrder();

            var orderTable = new OrderTable {Order = new Order {ID = orderId}, Table = new Table {ID = tableID}};
            Repository.Add(orderTable);

            return orderTable.ID;
        }

        public bool CheckTableStatus(long tableID)
        {
            var result = Repository.Find(x => x.Table.ID == tableID);
            return result.Any();
        }
    }
}