using Microsoft.VisualStudio.TestTools.UnitTesting;
using TM.CoreServices;
using TM.CoreServices.Contracts;
using TM.DataContracts;
using TM.Infrastructure.Entities;

namespace UnitTest
{
    [TestClass]
    public class RepositoryTests
    {
        private ICategoryServices _categoryServices;
        public ICategoryServices CategoryBusinessServices
        {
            get { return _categoryServices ?? (_categoryServices = new CategoryServices()); }
        }

        [TestMethod]
        public void AddCategoryTest()
        {
            var categoryDTO = new CategoryDTO
                               {
                                   CategoryName = "cat1"
                               };
            var result = CategoryBusinessServices.AddCategory(categoryDTO);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }
    }
}
