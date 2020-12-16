using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Business.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var categoryList = _categoryService.GetList();
            if (categoryList.Success)
            {
                return View(categoryList.Data);
            }
            return HttpNotFound();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = _categoryService.GetById(id.Value);
            if (!result.Success)
            {
                return HttpNotFound();
            }
            return View(result.Data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            _categoryService.Add(category);
            return View(category);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = _categoryService.GetById(id.Value);
            if (!result.Success)
            {
                return HttpNotFound();
            }
            return View(result.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var cat = _categoryService.GetById(category.Id);
            if (!cat.Success)
            {
                return HttpNotFound();
            }
            cat.Data.Description = category.Description;
            cat.Data.Title = category.Title;
            _categoryService.Update(cat.Data);
            return View(category);
        }
        
    }
}