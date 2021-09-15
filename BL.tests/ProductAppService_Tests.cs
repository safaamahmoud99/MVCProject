using BL.AppServices;
using BL.ViewModel;
using NUnit.Framework;
using System;

namespace BL.tests
{
    class ProductAppService_Tests
    {
        ProductAppService productAppService = new ProductAppService();

        [Test]
        [TestCase(44, true)]
        [TestCase(162, true)]
        public void ProductInsertOrUpdate_Test(int id, bool expectedValue)
        {
            var fakeProduct = new ProductViewModel
            {
                Id = id,
                Name = "Product Name"
            };

            bool res;

            if (productAppService.CheckOrderExists(fakeProduct))
            {
                res = productAppService.UpdateProduct(fakeProduct);
            }
            else
            {
                res = productAppService.SaveNewProduct(fakeProduct);
            }

            Assert.That(res, Is.EqualTo(expectedValue));
        }

        [Test]
        public void CreateNewProduct_Test()
        {
            var fakeProduct = new ProductViewModel
            {
                Name = "new Product Name"
            };
            var res = productAppService.SaveNewProduct(fakeProduct);

            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void UpdateExistProduct_Test()
        {
            var existProduct = productAppService.GetAllProducts()[1];

            existProduct.Name = "Change Name Test";

            var res = productAppService.UpdateProduct(existProduct);

            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void UpdateProduct_NotExistTest()
        {
            var fakeProduct = new ProductViewModel
            {
                Name = "Fake Product Name"
            };

            Assert.That(() => productAppService.UpdateProduct(fakeProduct),
                               Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        [TestCase(703, false)]
        public void RemoveProduct_Test(int id, bool expectedValue)
        {
            var res = productAppService.DeleteProduct(id);

            Assert.That(res, Is.EqualTo(expectedValue));
        }

        [Test]
        public void DeleteProduct_ExistOrNotExistTest([Range(65, 130, 10)] int id)
        {
            bool res, expectedValue;

            if (productAppService.GetProduct(id) != null)
            {
                res = productAppService.DeleteProduct(id);
                expectedValue = true;

            }
            else
            {
                res = productAppService.DeleteProduct(id);
                expectedValue = false;
            }

            Assert.That(res, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(ExpectedResult = true)]
        public bool SearchProduct_TestCase()
        {
            string SearchKeyWord = "Product";

            var products = productAppService.Search(SearchKeyWord);

            foreach (var product in products)
            {
                if (!product.Name.ToLower().Contains(SearchKeyWord.ToLower()))
                    return false;
            }

            return true;
        }

        [Test]
        public void SearchProduct_TestName()
        {
            string SearchKeyWord = "Name";

            var products = productAppService.Search(SearchKeyWord);

            foreach (var product in products)
            {
                Assert.IsTrue(product.Name.ToLower().Contains(SearchKeyWord.ToLower()));
            }

        }
    }
}
