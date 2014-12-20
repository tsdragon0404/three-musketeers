using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SMS.Data
{
    public interface ICrossTableRepository
    {
        TTargetEntity CrossTableGetByID<TTargetEntity>(object id);
        TTargetEntity CrossTableGet<TTargetEntity>(Expression<Func<TTargetEntity, bool>> predicate);
        IEnumerable<TTargetEntity> CrossTableList<TTargetEntity>(Expression<Func<TTargetEntity, bool>> predicate);
        void CrossTableAdd(object item);
        void CrossTableUpdate(object item);
        void CrossTableDelete<TTargetEntity>(object id);
    }
}