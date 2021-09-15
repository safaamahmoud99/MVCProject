using BL.AppServices;
using BL.ViewModel;
using NUnit.Framework;

namespace BL.tests
{
    class PaypalAppService_Tests
    {
        PaypalAppService paypalAppService ;

        [SetUp]
        public void SetUp()
        {
            paypalAppService = new PaypalAppService();
        }

        [Test]
        [TestCase(1)]
        [TestCase(20)]
        [TestCase(33)]
        public void PayPalUpdate_Test(int id)
        {
            var paypalView = new PaypalViewModel
            {
                Id = id,
                Account = "aaa"
            };

            bool res = false , expectedValue;

            if (paypalAppService.CheckPaypalExists(paypalView))
            {
                res = paypalAppService.UpdatePaypal(paypalView);
                expectedValue = true;
            }
            else
                expectedValue = false;


            Assert.That(res, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetPaypal_Test()
        {
            int fakeId = 9045;

            var fakePayPal = paypalAppService.GetPaypal(fakeId);

            Assert.That(fakePayPal, Is.Null);
        }

        [Test]
        public void DeletePaypal_ExistOrNotExistTest([Range(50,100,10)]int id )
        {
            bool res , expectedValue;

            if (paypalAppService.GetPaypal(id) != null)
            {
                expectedValue = true;
            }
            else
            {
                expectedValue = false;
            }

               res = paypalAppService.DeletePaypal(id);

            Assert.That(res, Is.EqualTo(expectedValue));
        }

    }
}
