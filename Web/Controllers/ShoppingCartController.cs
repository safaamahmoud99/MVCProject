using AutoMapper;
using BL.AppServices;
using BL.Configur;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        protected readonly IMapper Mapper = MapperConfig.Mapper;

        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
        ProductAppService ProductsAppService = new ProductAppService();
        ShoppingCartProductsAppService shoppinfCartProductAppService = new ShoppingCartProductsAppService();

        [Authorize]
        public ActionResult ViewCart()
        {
            AccountAppService accountAppService = new AccountAppService();
            string id = accountAppService.FindByName(User.Identity.Name).Id;
            var shopCart = shoppingCartAppService.GetShoppingCart(id);
            if (shopCart == null)
                return View(shopCart);
            var Products = new List<ProductViewModel>();
            foreach (var item in shopCart.ShoppingCartProducts)
            {
                Products.Add(ProductsAppService.GetProduct(item.productId));
            }
            ViewBag.ShopingCartProducrs = Products;
            return View(shopCart);
        }

        [Authorize]
        public ActionResult RemoveProduct(int ShopCartProductId, double price, int quantity)
        {
            AccountAppService accountAppService = new AccountAppService();
            string ShopCartId = accountAppService.FindByName(User.Identity.Name).Id;

            var shoppingcart = shoppingCartAppService.GetShoppingCart(ShopCartId);
            //var productId = shoppinfCartProductAppService.GetShoppingCartProducts(ShopCartProductId).productId;
            shoppingcart.totalPrice -= price * quantity; //shoppinfCartProductAppService.GetShoppingCartProducts(ShopCartProductId).Quantity * ProductsAppService.GetProduct(productId).Price;

            shoppinfCartProductAppService.DeleteShoppingCartProducts(ShopCartProductId);
            shoppingCartAppService.UpdateShoppingCart(shoppingcart);
            return RedirectToAction("ViewCart", new { id = ShopCartId });
        }
    }
}