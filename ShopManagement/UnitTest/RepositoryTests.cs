using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TM.Infrastructure.Data;
using TM.Infrastructure.Data.BusinessServices;
using TM.Infrastructure.Entities;
using TM.Interfaces.BusinessServices;

namespace UnitTest
{
    [TestClass]
    public class RepositoryTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var container = new WindsorContainer();
            container.Install(new DomainInstaller());
        }
        public ICategoryBusinessServices CategoryBusinessServices { get; set; }

        [TestMethod]
        public void AddCategoryTest()
        {
            var category = new Category
                               {
                                   CategoryName = "cat1"
                               };
            CategoryBusinessServices.AddCategory(category);

        }
    }
}
