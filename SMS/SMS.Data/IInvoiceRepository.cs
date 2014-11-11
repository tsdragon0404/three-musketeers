using SMS.Data.Entities;

namespace SMS.Data
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        void CreateInvoice(Order order, long userID, string currency, decimal tax, decimal serviceFee);
    }
}