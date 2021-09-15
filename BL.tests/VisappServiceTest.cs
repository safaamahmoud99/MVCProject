using BL.AppServices;
using BL.ViewModel;
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
    class VisappServiceTest
    {
        VisaAppService visaAppService;
        VisaViewModel visa;
        

        [SetUp]
        public void Setup()
        {
            visaAppService = new VisaAppService();
            visa = new VisaViewModel();
        }
        [Test]
        public void Save_New_visa_Test_null_argument()
        {
            Assert.That(() => visaAppService.SaveNewVisa(null), Throws.TypeOf<ArgumentNullException>());
        }


        [Test]
        public void Update_visa_null_argument()
        {
            Assert.That(() => visaAppService.UpdateVisa(null), Throws.TypeOf<ArgumentNullException>());
        }
        [TestCase(-10)]
        public void Get_visa_Test(int id)
        {
            Assert.That(() =>visaAppService.GetVisa(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        [TestCase(-9)]
        public void Delete_visa_Test(int id)
        {
            Assert.That(() =>visaAppService.DeleteVisa(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Check__visa_Test_null_argument()
        {
            Assert.That(() => visaAppService.CheckVisaExists(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
