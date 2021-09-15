using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using AutoMapper;
using BL.Configur;

namespace Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        AccountAppService accountAppService = new AccountAppService();
        // GET: Admin
        public ActionResult Index(int? page)
        {
            OrderAppService orderAppService = new OrderAppService();
            List<OrderViewModel> orders = orderAppService.GetAllOrdersDecendingByTime();
            int pageNumber = (page ?? 1);

            return View(orders.ToPagedList(pageNumber, 10));
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin(RegisterViewodel admin)
        {
            if (ModelState.IsValid == false)
            {
                return View(admin);
            }
            IdentityResult result = accountAppService.Register(admin);
            if (result.Succeeded)
            {
                ApplicationUserIDentity identityUser = accountAppService.Find(admin.UserName, admin.PasswordHash);

                accountAppService.AssignToRole(identityUser.Id, "Admin");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(admin);
            }
        }

        public ActionResult OrderDetails(int id)
        {
            OrderAppService orderAppService = new OrderAppService();
            OrderedProductsAppService orderedProductsAppService = new OrderedProductsAppService();
            PaymentMethodAppService paymentMethodAppService = new PaymentMethodAppService();
            ProductAppService productAppService = new ProductAppService();
            UserAppService userAppService = new UserAppService();

            var order = orderAppService.GetOrder(id);
            var orderedProducts = orderedProductsAppService.GetAllOrderedProducts().Where(op => op.orderId == id);
            var paymentMethod = paymentMethodAppService.GetPaymentMethod(id);

            var user = userAppService.GetApplicationUserIDentity(order.userId);
            ViewBag.Address = user.Address;
            if (paymentMethod.Method == "Paypal")
            {
                PaypalAppService paypalAppService = new PaypalAppService();
                ViewBag.paypal = paypalAppService.GetPaypal(id).Account;
            }
            else if(paymentMethod.Method == "Visa")
            {
                VisaAppService visaAppService = new VisaAppService();
                ViewBag.visa = visaAppService.GetVisa(id);
            }

            List<OrderedProducts> orderedProducts1 = new List<OrderedProducts>();
            foreach(var orderedProduct in orderedProducts)
            {
                var product = productAppService.GetProduct(orderedProduct.productId);
                OrderedProducts orderedProduct2 = new OrderedProducts();
                orderedProduct2.Product = Mapper.Map<Product>(product);
                orderedProduct2.Quantity = orderedProduct.Quantity;
                orderedProducts1.Add(orderedProduct2);
            }
            ViewBag.paymentMethod = paymentMethod;
            ViewBag.orderedProducts = orderedProducts1;
            return View(order);
        }
    }
}