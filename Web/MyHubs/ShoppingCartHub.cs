using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.AppServices;
using DAL;
using BL.Configur;
using BL.ViewModel;
using Microsoft.AspNet.Identity;

namespace Web.MyHubs
{
    [HubName("ShoppingCartHub")]
    public class ShoppingCartHub : Hub
    {
        [HubMethodName("AddToCart")]
        public void AddToCart(string userId, int productId)
        {
            ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
            shoppingCartAppService.AddProduct(userId, productId);
            UpdateCart(userId);
        }

        [HubMethodName("UpdateCart")]
        public void UpdateCart(string userId)
        {
            int quantity = 0;
            ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
            ShoppingCartViewModel shoppingCart = shoppingCartAppService.GetShoppingCart(userId);
            ProductAppService productAppService = new ProductAppService();
            if (shoppingCart != null)
            {
                if(shoppingCart.ShoppingCartProducts != null)
                {
                    shoppingCart.totalPrice = 0;
                    foreach (ShoppingCartProducts shoppingCartProducts in shoppingCart.ShoppingCartProducts)
                    {
                        quantity += shoppingCartProducts.Quantity;
                        shoppingCart.totalPrice += quantity * productAppService.GetProduct(shoppingCartProducts.productId).Price;
                    }
                    shoppingCartAppService.UpdateShoppingCart(shoppingCart);
                }
            }
            Clients.All.updateTotal(shoppingCart.totalPrice, userId);
            Clients.All.UpdateCart(quantity, userId);
        }

        [HubMethodName("UpdateQuantity")]
        public void UpdateQuantity(string userid, int shoppingCartProductId, int quantity)
        {

            ShoppingCartProductsAppService shoppingCartProductsAppService = new ShoppingCartProductsAppService();
            ProductAppService productAppService = new ProductAppService();
            var shoppingCartProduct = shoppingCartProductsAppService.GetShoppingCartProducts(shoppingCartProductId);
            var product = productAppService.GetProduct(shoppingCartProduct.productId);
            if(product.Quantity >= quantity)
            {
                shoppingCartProduct.Quantity = quantity;
                shoppingCartProductsAppService.UpdateShoppingCartProducts(shoppingCartProduct);
            }
            else
            {
                Clients.All.unavialableQuantity(shoppingCartProduct.Quantity, shoppingCartProductId, userid);
            }

            UpdateCart(userid);
        }
    }
}