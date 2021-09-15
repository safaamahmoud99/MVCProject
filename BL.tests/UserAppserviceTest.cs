using BL.AppServices;
using DAL;
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
    class UserAppserviceTest
    {
               
  
            UserAppService userAppService;
            ApplicationUserIDentity user;
  
            [SetUp]
            public void Setup()
            {
                userAppService = new UserAppService();
                user = new ApplicationUserIDentity();
            }

        [Test]
        public void Save_New_user_Test_null_argument()
        {
            Assert.That(() => userAppService.SaveNewApplicationUserIDentity(null),Throws.TypeOf<ArgumentNullException>());
        }


        [Test]
        public void Update_user_null_argument()
        {
            Assert.That(() => userAppService.UpdateApplicationUserIDentity(null), Throws.TypeOf<ArgumentNullException>());
        }
        [TestCase("")]
        public void Get_user_Test(string id)
        {
            Assert.That(() => userAppService.GetApplicationUserIDentity(id), Throws.TypeOf<ArgumentNullException>());
        }


        [TestCase(-9)]
        public void Delete_user_Test(int id)
        {
            Assert.That(() => userAppService.DeleteApplicationUserIDentity(id),Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Check_user_Exists_Test_null_argument()
        {
            Assert.That(() => userAppService.CheckApplicationUserIDentityExists(null), Throws.TypeOf<ArgumentNullException>());
        }

    }
}
