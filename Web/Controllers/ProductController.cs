using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModel;

namespace Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.categories = categoryAppService.GetAllCategories();
            return View(productAppService.GetAllProducts());
        }

        public ActionResult Create()
        {

            ViewBag.categories = categoryAppService.GetAllCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel, HttpPostedFileBase Image)
        {
            ViewBag.categories = categoryAppService.GetAllCategories();
            if (ModelState.IsValid == false)
            {
                return View(productViewModel);
            }

            if (Image != null)
            {
                if (Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Resources/images"), fileName);
                    Image.SaveAs(path);
                    productViewModel.Image = fileName;
                    
                    productAppService.SaveNewProduct(productViewModel);
                    return RedirectToAction("Index");
                }
            }
            
            ModelState.AddModelError("Image", "Image must entered");
            return View(productViewModel);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.categories = categoryAppService.GetAllCategories();
            return View(productAppService.GetProduct(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel productViewModel, HttpPostedFileBase Image)
        {
            ViewBag.categories = categoryAppService.GetAllCategories();
            if (ModelState.IsValid == false)
                return View(productViewModel);
            if (Image != null)
            { 
                if (Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Resources/images"), fileName);
                    Image.SaveAs(path);
                    productViewModel.Image = fileName;
                }
            }
            if(productViewModel.Image == null)
            {
                productViewModel.Image = productAppService.GetProduct(id).Image;
            }
            productAppService.UpdateProduct(productViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            productAppService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}