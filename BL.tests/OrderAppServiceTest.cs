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
    public class OrderAppServiceTest
    {
        OrderAppService orderAppService;

        [SetUp]
        public void Setup()
        {
            orderAppService = new OrderAppService();
        }

        [TestCase(-10)]
        public void GetOrderTest(int id)
        {
            Assert.That(() => orderAppService.GetOrder(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void SaveNewOrderTest_null_argument()
        {
            Assert.That(() => orderAppService.SaveNewOrder(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void SaveNewOrderTest_null_or_empity_userid(string userid)
        {
            OrderViewModel Order = new OrderViewModel() { userId = userid };
            Assert.That(() => orderAppService.SaveNewOrder(Order), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateOrderTest_null_argument()
        {
            Assert.That(() => orderAppService.UpdateOrder(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void UpdateOrderTest_null_or_empity_userid(string userid)
        {
            OrderViewModel Order = new OrderViewModel() { userId = userid };
            Assert.That(() => orderAppService.UpdateOrder(Order), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(-10)]
        public void DeleteOrderTest(int id)
        {
            Assert.That(() => orderAppService.DeleteOrder(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckOrderExistsTest_null_argument()
        {
            Assert.That(() => orderAppService.CheckOrderExists(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
