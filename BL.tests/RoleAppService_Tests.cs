using BL.AppServices;
using NUnit.Framework;

namespace BL.tests
{
    class RoleAppService_Tests
    {
        RoleAppService roleAppService;
        [SetUp]
        public void SetUp()
        {
            roleAppService = new RoleAppService();
        }

        [Test]
        public void Create_NullTest()
        {
            var res = roleAppService.Create("admin");

            Assert.That(res, Is.Not.EqualTo(null));
        }

        [Test]
        public void Create_AddAlredyExistTest()
        {
            roleAppService.Create("Creater");
            var res = roleAppService.Create("Creater");

            Assert.That(res.Succeeded, Is.False);
        }
    }
}
