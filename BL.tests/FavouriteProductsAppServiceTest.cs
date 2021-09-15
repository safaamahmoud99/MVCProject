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
    public class FavouriteProductsAppServiceTest
    {
        FavouriteProductsAppService favouriteProductsAppService;

        [SetUp]
        public void Setup()
        {
            favouriteProductsAppService = new FavouriteProductsAppService();
        }

        [TestCase(-10)]
        public void GetFavouriteProductsTest(int id)
        {
            Assert.That(() => favouriteProductsAppService.GetFavouriteProducts(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void SaveNewFavouriteProductsTest_null_argument()
        {
            Assert.That(() => favouriteProductsAppService.SaveNewFavouriteProducts(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("123456")]
        public void SaveNewFavouriteProductsTest_null_or_empity_userid(string userid)
        {
            FavouriteProducts favouriteProducts = new FavouriteProducts() { userId = userid };
            Assert.That(() => favouriteProductsAppService.SaveNewFavouriteProducts(favouriteProducts), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateFavouriteProductsTest_null_argument()
        {
            Assert.That(() => favouriteProductsAppService.UpdateFavouriteProducts(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("123456")]
        public void UpdateFavouriteProductsTest_null_or_empity_userid(string userid)
        {
            FavouriteProducts favouriteProducts = new FavouriteProducts() { userId = userid };
            Assert.That(() => favouriteProductsAppService.UpdateFavouriteProducts(favouriteProducts), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(-10)]
        public void DeleteFavouriteProductsTest(int id)
        {
            Assert.That(() => favouriteProductsAppService.DeleteFavouriteProducts(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckFavouriteProductsExistsTest_null_argument()
        {
            Assert.That(() => favouriteProductsAppService.CheckFavouriteProductsExists(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void AddProductToUserListTest_null_or_empity_userid(string userid)
        {
            Assert.That(() => favouriteProductsAppService.AddProductToUserList(userid,0), Throws.TypeOf<ArgumentException>());
        }
    }
}
