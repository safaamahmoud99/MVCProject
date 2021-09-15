using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Web.Controllers
{
    public class FavouriteProductsController : Controller
    {
        FavouriteProductsAppService favroteProductsAppService = new FavouriteProductsAppService();
        UserAppService userAppService = new UserAppService();

        //Delete product from Fav list
        public ActionResult Delete(string UserId, int ProductId)
        {
            favroteProductsAppService.DeleteFavouriteProducts(ProductId);

            return RedirectToAction("FavList", "User");
        }

        //Add product To Fav list
        public ActionResult AddToFav(int ProductId)
        {
            AccountAppService accountAppService = new AccountAppService();

            var userId = accountAppService.FindByName(User.Identity.Name).Id;
            var user = userAppService.GetUserWhere(u => u.Id == userId , "FavouriteProducts").FirstOrDefault();
            var favproducts = favroteProductsAppService.GetAllFavouriteProducts();
            foreach(var item in user.FavouriteProducts)
            {
                if(item.productId == ProductId)
                {
                    return RedirectToAction("FavList", "User");
                }
            }
            FavouriteProducts favouriteProducts = new FavouriteProducts();
            favouriteProducts.productId = ProductId;
            favouriteProducts.userId = userId;
            favroteProductsAppService.SaveNewFavouriteProducts(favouriteProducts);

            return RedirectToAction("FavList", "User");
        }
    }
}