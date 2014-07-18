namespace SMS.Common.AppLock
{
    public static class ApplicationLock
    {
        private static LockGroup<Payment> payment;

        public static LockGroup<Payment> Payment
        {
            get { return payment ?? (payment = new LockGroup<Payment>()); }
            set { payment = value; }
        }
    }
}