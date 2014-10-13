using Autofac;

namespace SMS.Common
{
    public static class ServiceLocator
    {
        private static IContainer Container { get; set; }

        public static void Initialize(IContainer container)
        {
            Container = container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}