using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>, ICrossTableRepository
    {
        void CreateInvoice(Order order, long userID, string currency, decimal tax, decimal serviceFee, string taxInfo, PaymentMethod paymentMethod);
    }
}