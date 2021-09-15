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
    public class CategoryAppServiceTest
    {
        CategoryAppService categoryAppService;

        [SetUp]
        public void Setup()
        {
            categoryAppService = new CategoryAppService();
        }

        [TestCase(-10)]
        public void GetCategoryTest(int id)
        {
            Assert.That(()=>categoryAppService.GetCategory(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void SaveNewCategoryTest_null_variable()
        {
            Assert.That(() => categoryAppService.SaveNewCategory(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SaveNewCategoryTest_null_name()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            Assert.That(() => categoryAppService.SaveNewCategory(categoryViewModel), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void SaveNewCategoryTest_empity_string_name()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel() { Name = "" };
            Assert.That(() => categoryAppService.SaveNewCategory(categoryViewModel), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateCategoryTest_null_variable()
        {
            Assert.That(() => categoryAppService.SaveNewCategory(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateCategoryTest_null_name()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            Assert.That(() => categoryAppService.SaveNewCategory(categoryViewModel), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateCategoryTest_empity_string_name()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel() { Name = "" };
            Assert.That(() => categoryAppService.SaveNewCategory(categoryViewModel), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(-10)]
        public void DeleteCategoryTest(int id)
        {
            Assert.That(() => categoryAppService.GetCategory(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckCategoryExistsTest_null_variable()
        {
            Assert.That(() => categoryAppService.SaveNewCategory(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CheckCategoryExistsTest_null_name()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            Assert.That(() => categoryAppService.SaveNewCategory(categoryViewModel), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckCategoryExistsTest_empity_string_name()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel() { Name = "" };
            Assert.That(() => categoryAppService.SaveNewCategory(categoryViewModel), Throws.TypeOf<ArgumentException>());
        }
    }
}
