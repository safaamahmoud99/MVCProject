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

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        public ActionResult Index()
        {
            ViewBag.categories = categoryAppService.GetAllCategories();
            return View(productAppService.GetAllProducts());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string proName)
        {
            ViewBag.categories = categoryAppService.GetAllCategories();
            List<ProductViewModel> productViewModels = productAppService.Search(proName);
            return View("index", productViewModels);
        }

        public ActionResult Product(int id)
        {
            ProductViewModel productViewModel = productAppService.GetProduct(id);
            return View(productViewModel);
        }

        public ActionResult GetProductsByCategory(int id)
        {
            ViewBag.cats = categoryAppService.GetAllCategories();
            ViewBag.categories = categoryAppService.GetAllCategories();
            return View("index", productAppService.GetAllProducts().Where(p => p.CategoryId == id).ToList());
        }
    }
}