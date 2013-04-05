//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;

//namespace TM.Infrastructure.Data
//{
//    public class DomainInstaller : IWindsorInstaller
//    {
//        public void Install(IWindsorContainer container, IConfigurationStore store)
//        {
//            container.Register(
//                Types.FromThisAssembly()
//                    .Where(t => t.Name.EndsWith("Service"))
//                    .WithService.DefaultInterfaces()
//                    .Configure(x => x.LifestyleSingleton()),
//                Types.FromThisAssembly()
//                    .Where(t => t.Name.EndsWith("Repository"))
//                    .WithService.DefaultInterfaces()
//                    .Configure(x => x.LifestyleSingleton())
//                );
//        }
//    }
//}
