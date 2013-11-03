using Autofac;

namespace TM.Utilities
{
    public static class ObjectResolver
    {
        public static ILifetimeScope LifetimeScope { get; set; }

        public static TService Resolve<TService>()
        {
            return LifetimeScope.Resolve<TService>();
        }
    }
}
