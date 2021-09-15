using BL.AppServices;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace BL.tests
{
    class PaymentMethodAppService_Tests
    {
        PaymentMethodAppService paymentMethodAppService ;

        [SetUp]
        public void SetUp()
        {
            paymentMethodAppService = new PaymentMethodAppService();
        }

        [Test]
        public void GetAllPaymentMethods_NullTest()
        {
            var res = paymentMethodAppService.GetAllPaymentMethods();

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public void GetAllPaymentMethods_ResultTypeTest()
        {
            var res = paymentMethodAppService.GetAllPaymentMethods();

            Assert.That(res, Is.InstanceOf<List<PaymentMethod>>());
        }

        [Test]
        public void GetPaymentMethod_notExistTest()
        {
            int fakeId = 1090;

            var fakePaymentMethod = paymentMethodAppService.GetPaymentMethod(fakeId);

            Assert.That(fakePaymentMethod, Is.Null);
        }

       
        [Test]
        public void UpdatePaymentMethod_Test()
        {
            var fakePaymentMethod = paymentMethodAppService.GetPaymentMethod(3);

            if (fakePaymentMethod == null)
            {
                Assert.That(() => paymentMethodAppService.UpdatePaymentMethod(fakePaymentMethod),
                               Throws.TypeOf<ArgumentNullException>());
            }
            else
            {
                fakePaymentMethod.Method = "Paypal";
                var res = paymentMethodAppService.UpdatePaymentMethod(fakePaymentMethod);

                Assert.That(res, Is.EqualTo(true));
            }
        }

        [Test]
        public void UpdatePaymentMethod_NotExistTest()
        {
            var fakePaymentMethod = new PaymentMethod
            {
                Method = "Visa",
                Id = 1664
            };

            Assert.That(() => paymentMethodAppService.UpdatePaymentMethod(fakePaymentMethod),
                               Throws.TypeOf<DbUpdateConcurrencyException>());
        }

        [Test]
        [TestCase(460, false)]
        [TestCase(730, false)]
        public void DeletePaymentMethod_Test(int id, bool expectedValue)
        {
            var res = paymentMethodAppService.DeletePaymentMethod(id);

            Assert.That(res, Is.EqualTo(expectedValue));
        }

        [Test]
        public void DeletePaymentMethod_ExistOrNotExistTest([Range(100, 200, 11)] int id)
        {
            bool res, expectedValue;

            if (paymentMethodAppService.GetPaymentMethod(id) != null)
            {
                expectedValue = true;
            }
            else
            {
                expectedValue = false;
            }
            res = paymentMethodAppService.DeletePaymentMethod(id);

            Assert.That(res, Is.EqualTo(expectedValue));
        }

    }
}
