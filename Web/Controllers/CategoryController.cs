using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModel;

namespace Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        // GET: Category
        public ActionResult Index()
        {
            return View(categoryAppService.GetAllCategories());
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid == false)
                return View(categoryViewModel);
            categoryAppService.SaveNewCategory(categoryViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(categoryAppService.GetCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid == false)
                return View(categoryViewModel);

            categoryAppService.UpdateCategory(categoryViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            categoryAppService.DeleteCategory(id);
            return RedirectToAction("Index"); //can not refresh
        }

    }
}