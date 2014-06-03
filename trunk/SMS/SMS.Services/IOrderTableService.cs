﻿using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IOrderTableService : IBaseService<OrderTableDto, long>
    {
        ServiceResult<IList<TDto>> GetTablesByAreaID<TDto>(long areaID);
        ServiceResult<long> CreateOrderTable(long tableID);
        ServiceResult CheckTableStatus(long tableID);
    }
}