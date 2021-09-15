using AutoMapper;
using BL.AppServices;
using BL.Configur;
using BL.ViewModel;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        FavouriteProductsAppService favroteProductsAppService = new FavouriteProductsAppService();
        UserAppService userAppService = new UserAppService();
        ProductAppService ProductsAppService = new ProductAppService();
        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
        protected readonly IMapper Mapper = MapperConfig.Mapper;



        //disply user favorite List  using User id as parameter
        public ActionResult FavList()
        {
            AccountAppService accountAppService = new AccountAppService();
            string id = accountAppService.FindByName(User.Identity.Name).Id;
            var user = userAppService.GetUserWhere(u => u.Id == id, "FavouriteProducts")
                .FirstOrDefault();
            var favProducts = new Dictionary<int, ProductViewModel>();
            foreach (var item in user.FavouriteProducts)
            {
                favProducts[item.Id] = (ProductsAppService.GetProduct(item.productId));
            }
            ViewBag.userId = user.Id;
            return View(favProducts);
        }


        


        //Add product to user Fav List using
        //User id and product Id as parameters
        //~/User/AddToFavList/?UserId=ee&&ProductId=3
        public ActionResult AddToFavList(string UserId, int ProductId)
        {

            favroteProductsAppService.AddProductToUserList(UserId, ProductId);
            return RedirectToAction("FavList");

        }
    }
}