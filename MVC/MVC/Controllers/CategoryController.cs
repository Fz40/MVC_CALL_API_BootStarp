using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService ImpCat;

        public CategoryController(ICategoryService _ImpCat)
        {
            ImpCat = _ImpCat;
        }
        // GET: Category
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var res = await ImpCat.GetAll_Categoty();
            return View(res);
        }

        // GET: Category/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Cat = await ImpCat.GetCategoryById(id);
            if (Cat  != null)
            {
                return View(Cat);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(CategoryModel CatModel)
        {
            try
            {
                var status = await ImpCat.CreateCategory(CatModel);
                if (status == "Created")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View();
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Category/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Cat = await ImpCat.GetCategoryById(id);
            if (Cat != null)
            {
                return View(Cat);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CategoryModel CatModel)
        {
            try
            {
                var status = await ImpCat.UpdateCategory(CatModel);
                if (status == "NoContent")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Category/Delete/5
        [HttpGet]
        public async Task<ActionResult> Deleted(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Cat = await ImpCat.GetCategoryById(id);
            if (Cat != null)
            {
                return View(Cat);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Deleted(int id, CategoryModel CatModel)
        {
            try
            {
                var status = await ImpCat.DeleteCategory(id);
                if (status == "NoContent" || status == "Ok")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

    }
}
