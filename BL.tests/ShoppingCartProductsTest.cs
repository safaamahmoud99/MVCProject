using BL.AppServices;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.tests
{
    class ShoppingCartProductsTest
    {
      ShoppingCartProductsAppService productCartAppService;
        [SetUp]
        public void Initial()
        {
           productCartAppService = new ShoppingCartProductsAppService();
        }
        [Test]
        public void Save_New_Shopping_Cart_Products_Test_null_argument()
        {
            Assert.That(() => productCartAppService.SaveNewShoppingCartProducts(null), Throws.TypeOf<ArgumentNullException>());
        }


        [Test]
        public void Update_Shopping_CartProductsTest_null_argument()
        {
            Assert.That(() => productCartAppService.UpdateShoppingCartProducts(null), Throws.TypeOf<ArgumentNullException>());
        }
        [TestCase( -10)]
        public void Get_Shopping_Cart_Products_Test(int id)
        {
          Assert.That(() => productCartAppService.GetShoppingCartProducts(id),Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        
        [TestCase(-9)]
        public void Delete_shopping_ProductsTest(int id)
        {
            Assert.That(() => productCartAppService.DeleteShoppingCartProducts(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Check_ShoppingCart_ProductsExists_Test_null_argument()
        {
            Assert.That(() =>productCartAppService.CheckShoppingcartproductsExists(null), Throws.TypeOf<ArgumentNullException>());
        }

        


    }
}
