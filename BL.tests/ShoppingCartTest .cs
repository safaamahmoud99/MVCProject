using BL.AppServices;
using DAL;
using BL.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.tests
{
    class ShoppingCartTest
    {
        
            ShoppingCartAppService shoppingCartAppService;
            ShoppingCartViewModel shoppingCart;

            [SetUp]
            public void Setup()
            {
            shoppingCartAppService = new ShoppingCartAppService();
            shoppingCart = new ShoppingCartViewModel();
            }
        [TestCase(null)]
        public void Get_Shopping_Cart_Test(String id)
        {
            Assert.That(()=>shoppingCartAppService.GetShoppingCart(id),Throws.TypeOf
                <ArgumentOutOfRangeException>());
        }

        [Test]
        public void Save_New_Shopping_Cart_test_null_variable()
        {
            Assert.That(() => shoppingCartAppService.SaveNewShoppingCart(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Save_New_Shopping_Cart_test()
        {
           ShoppingCartViewModel shoppingCart = new ShoppingCartViewModel() { Id = "",totalPrice=-7 };
            Assert.That(() => shoppingCartAppService.SaveNewShoppingCart(shoppingCart),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Update_Shopping_Cart_Test_null_variable()
        {
            Assert.That(() =>shoppingCartAppService.UpdateShoppingCart(null), Throws.TypeOf
                <ArgumentNullException>());
        }

        [TestCase(null)]
        public void Delete_Shopping_Cart_est(string id)
        {
            Assert.That(() =>shoppingCartAppService.DeleteShoppingCart(null), Throws.
                TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Check_Shopping_Cart_Exists_Test_null_variable()
        {
            Assert.That(() =>shoppingCartAppService.CheckShoppingcartExists(null), Throws.TypeOf<ArgumentNullException>());
        }
        
    }
}
