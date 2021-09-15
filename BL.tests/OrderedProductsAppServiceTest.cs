using BL.AppServices;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModel;

namespace BL.tests
{
    public class OrderedProductsAppServiceTest
    {
        OrderedProductsAppService orderedProductsAppService;

        [SetUp]
        public void Setup()
        {
            orderedProductsAppService = new OrderedProductsAppService();
        }

        [TestCase(-10)]
        public void GetOrderedProductsTest(int id)
        {
            Assert.That(() => orderedProductsAppService.GetOrderedProducts(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void SaveNewOrderedProductsTest_null_argument()
        {
            Assert.That(() => orderedProductsAppService.SaveNewOrderedProducts(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateOrderedProductsTest_null_argument()
        {
            Assert.That(() => orderedProductsAppService.UpdateOrderedProducts(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(-10)]
        public void DeleteOrderedProductsTest(int id)
        {
            Assert.That(() => orderedProductsAppService.DeleteOrderedProducts(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckFavouriteProductsExistsTest_null_argument()
        {
            Assert.That(() => orderedProductsAppService.CheckOrderedProductsExists(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
