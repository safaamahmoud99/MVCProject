using BL.AppServices;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        ProductAppService productAppService = new ProductAppService();
        OrderAppService orderAppService = new OrderAppService();
        VisaAppService visaAppService = new VisaAppService();
        PaypalAppService PaypalAppService = new PaypalAppService();
        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();

        [Authorize]
        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checkout(VisaViewModel visa, PaypalViewModel paypal, string PaymentMethod)
        {
            PaymentMethod payMethod = new PaymentMethod();
            payMethod.Method = PaymentMethod;
            AccountAppService accountAppService = new AccountAppService();
            string id = accountAppService.FindByName(User.Identity.Name).Id;
            var shopCart = shoppingCartAppService.GetShoppingCart(id);

            var order = new OrderViewModel
            {
                PaymentMethod = payMethod,
                userId = shopCart.Id,
                totalPrice = shopCart.totalPrice,
                DateTime = DateTime.Now,
                OrderedProducts = new List<OrderedProducts>()
            };
            foreach (var item in shopCart.ShoppingCartProducts)
            {
                var orderProduct = new OrderedProducts
                {
                    productId = item.productId,
                    Quantity = item.Quantity

                };
                var product = productAppService.GetProduct(item.productId);
                product.Quantity -= item.Quantity;
                productAppService.UpdateProduct(product);
                order.OrderedProducts.Add(orderProduct);
            }
            shoppingCartAppService.DeleteShoppingCart(id);

            orderAppService.SaveNewOrder(order);

            if (PaymentMethod == "Visa")
            {
                visa.Id = payMethod.Id;
                visaAppService.SaveNewVisa(visa);
            }
            else if (PaymentMethod == "Paypal")
            {
                paypal.Id = payMethod.Id;
                PaypalAppService.SaveNewPaypal(paypal);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}