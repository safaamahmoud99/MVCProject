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
    public class AccountAppServiceTest
    {
        AccountAppService accountAppService;

        [SetUp]
        public void Setup()
        {
            accountAppService = new AccountAppService();
        }

        [TestCase("","")]
        [TestCase(null,null)]
        public void FindTest(string name, string password)
        {
            Assert.That(() => accountAppService.Find(name,password), Throws.TypeOf<ArgumentException>());
        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByNameTest(string name)
        {
            Assert.That(() => accountAppService.FindByName(name), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RegisterTest_null_argument()
        {
            Assert.That(() => accountAppService.Register(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void RegisterTest_embity_variables()
        {
            RegisterViewodel registerViewodel = new RegisterViewodel();
            registerViewodel.UserName = "";
            registerViewodel.Email = "";
            registerViewodel.PasswordHash = "";
            registerViewodel.ConfirmPassword = "";
            registerViewodel.Address = "";

            Assert.That(() => accountAppService.Register(registerViewodel), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RegisterTest_null_variables()
        {
            Assert.That(() => accountAppService.Register(new RegisterViewodel()), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RegisterTest_password_and_confirmPassword_not_equal()
        {
            RegisterViewodel registerViewodel = new RegisterViewodel();
            registerViewodel.UserName = "ss";
            registerViewodel.Email = "aa@email.com";
            registerViewodel.PasswordHash = "123456";
            registerViewodel.ConfirmPassword = "456789";
            registerViewodel.Address = "address";

            Assert.That(() => accountAppService.Register(registerViewodel), Throws.TypeOf<InvalidOperationException>());
        }

        [TestCase("","")]
        [TestCase(null,null)]
        public void AssignToRoleTest_null_or_empity_userid(string userid, string rolename)
        {
            Assert.That(() => accountAppService.AssignToRole(userid, rolename), Throws.TypeOf<ArgumentException>());
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        public void HasRoleTest_null_or_empity_userid(string userid, string rolename)
        {
            Assert.That(() => accountAppService.HasRole(userid, rolename), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateTest_null_argument()
        {
            Assert.That(()=>accountAppService.Update(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
