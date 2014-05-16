using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IInvoiceTableManagement : IBaseManagement<InvoiceTableDto, long>
    {
        IList<TDto> GetTablesByAreaID<TDto>(long areaID);
        long CreateInvoiceTable(long tableID);
        TDto GetTableDetail<TDto>(long invTblID);
        void UpdateTableDetail(long invTblID);
        bool CheckTableStatus(long tableID);
    }
}